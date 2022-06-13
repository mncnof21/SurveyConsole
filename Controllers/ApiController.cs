using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using SurveyConsole.Requests;
using SurveyConsole.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SurveyConsole.Models.Survdbpgsql;
using SurveyConsole.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using SurveyConsole.Libs;
using Newtonsoft.Json;
using SurveyConsole.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Data;

namespace SurveyConsole.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IConfiguration _config;
        private AppsSettings _appSettings = new AppsSettings();
        private survdbContext _survDB;
        private IWebHostEnvironment _hostingEnvironment;
        private Auth _auth;
        private UserRepository _userRepo;

        public ApiController (ILogger<ApiController> logger, IConfiguration config, IWebHostEnvironment hostingEnvironment, survdbContext survDB)
        {
            _logger = logger;
            _config = config;
            _config.Bind(_appSettings);
            _survDB = survDB;
            _hostingEnvironment = hostingEnvironment;
            SurveyRepository.db = _survDB;
            SurveyRepository.hostingEnv = _hostingEnvironment;
            _userRepo = new UserRepository(_survDB, _appSettings);
            _auth = new Auth(_survDB, _appSettings);
        }


        public string Generate(VwUser vwUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, vwUser.Nik),
                new Claim(ClaimTypes.GivenName, vwUser.Nama),
                new Claim(ClaimTypes.Role, vwUser.GroupCode)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddHours(9),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public VwUser Authenticate(FrmLogin frmlogin)
        {
            var currentUser = _userRepo.findUserAuth(frmlogin);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        [Route("ms-api/auth/login")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult LoginJWT([FromBody] FrmLogin frmlogin)
        {
            int statusCode = 200;
            var user = Authenticate(frmlogin);

            if (user != null)
            {
                var token = Generate(user);
                Dictionary<String, Object> dataUser = _auth.checkLoginData(frmlogin);
                statusCode = 200;
                HttpContext.Response.StatusCode = statusCode;
                return Json(new
                {
                    status = statusCode,
                    message = "OK",
                    data = dataUser,
                    token = token,
                });
            }

            return NotFound("User not found");
        }

        [Route("ms-api/auth/login2")]
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Login([FromBody] FrmLogin frmlogin)
        {
            int statusCode = 200;
            try
            {
                var errors = frmlogin.Validate();

                if (errors != null && errors.Count > 0)
                {
                    if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        statusCode = 422;
                        HttpContext.Response.StatusCode = statusCode;
                        return Json(new
                        {
                            status = statusCode,
                            message = "Validation error"
                        });
                    }
                    else
                    {
                        TempData["errors"] = errors;
                        return RedirectToAction("Login", "Auth");
                    }
                }

                List<String> jwt = _auth.checkLogin(frmlogin, HttpContext);
                Dictionary<String, Object> dataUser = _auth.checkLoginData(frmlogin);

                if (jwt != null && jwt.Count() > 0)
                {
                    statusCode = 200;
                    HttpContext.Response.StatusCode = statusCode;
                    return Json(new
                    {
                        status = statusCode,
                        message = "OK",
                        data = dataUser,
                        token = jwt.ElementAtOrDefault(0),
                        refreshToken = jwt.ElementAtOrDefault(1),
                    });
                }

                statusCode = 401;
                HttpContext.Response.StatusCode = statusCode;
                return Json(new
                {
                    status = statusCode,
                    message = "Unauthorized"
                });
            }
            catch (Exception e)
            {
                statusCode = 500;
                HttpContext.Response.StatusCode = statusCode;
                return Json(new
                {
                    status = statusCode,
                    message = e.Message + " " + e.StackTrace
                });
            }
        }

        [Route("ms-api/task/addsurvey")]
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 924288956)]
        [Authorize]
        public ActionResult Survey([FromForm] FrmSurvAddSurvey survey)
        {
            //if (!Oauth.IsValid(HttpContext)) return ExceptionHandlerUtils.JsonOutput(this, HttpContext, 401, "UnAuthorized");

            Dictionary<String, List<IFormFile>> formFiles = new Dictionary<string, List<IFormFile>>() { };

            if (HttpContext.Request.Form.Files != null && HttpContext.Request.Form.Files.Count > 0)
            {
                foreach (var item in HttpContext.Request.Form.Files)
                {
                    String itemName = item.Name.Replace("[]", "");
                    if (formFiles.Where(a => a.Key == itemName).Count() <= 0)
                    {
                        var FileCollection = HttpContext.Request.Form.Files.Where(a => a.Name == item.Name).ToList();
                        formFiles.Add(itemName, FileCollection);
                    }
                }
            }

            try
            {   
                List<VwMasterFormUpload> formList = _survDB.VwMasterFormUploads.ToList();
                SurveyRepository.CreateSurvey(HttpContext.Session.GetString("User"), survey, formList, formFiles);

                return Json(new
                {
                    status = 200,
                    message = "OK",
                    data = survey,
                    request = HttpContext.Request.Headers
                });
            }
            catch (Exception e)
            {

                HttpContext.Response.StatusCode = 500;
                return Json(new
                {
                    status = 500,
                    message = e.Message + e.StackTrace, //"Terjadi kesalahan saat memproses data!",  
                    data = survey,
                    request = HttpContext.Request.Headers
                });
            }
        }

        [HttpGet]
        public ActionResult GetTaskList()
        {
            int statusCode = 200;
            try
            {
                
                List<Tasklist> listTasklist = new List<Tasklist>() { };
                listTasklist = _survDB.Tasklists.Where(a => a.IsPush.Equals(1)).ToList();

                if (listTasklist != null && listTasklist.Count > 0)
                {
                    return Json(new
                    {
                        status = statusCode,
                        message = "OK",
                        data = listTasklist
                    });
                }
                else
                {
                    statusCode = 404;
                    HttpContext.Response.StatusCode = statusCode;
                    return Json(new
                    {
                        status = statusCode,
                        message = "Data tidak ditemukan!",
                        data = new List<object>().ToArray()
                    });
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                HttpContext.Response.StatusCode = statusCode;
                return Json(new
                {
                    status = statusCode,
                    //message = "Terjadi kesalahat saat mengambil data!",
                    message = e.Message,
                    data = new List<object>().ToArray()
                });
            }
        }

        [Route("ms-api/task/gethistorysurveylist")]
        [Authorize]
        [HttpGet]
        public ActionResult GetTaskSurveyHistory([FromQuery] string nik)
        {
            //var bodycontent = Utils.getBodyRawAsync(HttpContext.Request);
            //var obj = JsonConvert.DeserializeObject<NikRequest>(bodycontent.Result);
            //string nik = obj.nik;

            int statusCode = 200;
            try
            {
                //var query = from sc in _survDB.Set<SurveyresultClient>()
                //                      from tl in _survDB.Set<Tasklist>().Where(tl => sc.Taskid == tl.Id)
                //                      from ut in _survDB.Set<UserTask>().Where(ut => tl.Id == ut.TaskId)
                //                      where(ut.SurveyorNik==nik)
                //                      select new { sc };

                var query = from ut in _survDB.UserTasks
                            join tl in _survDB.Tasklists on ut.TaskId equals tl.Id
                            join src in _survDB.SurveyresultClients on ut.TaskId equals src.Taskid into data
                            from x in data.DefaultIfEmpty()
                            where (
                                ut.SurveyorNik == nik && 
                                tl.IsPush == 1 && 
                                x.Credate != null && 
                                (x.Credate >= DateTime.Now.AddDays(-7) && x.Credate <= DateTime.Now)
                            )
                            select new
                            {
                                survey_id = x.Id,
                                nik = ut.SurveyorNik,
                                nama = x.Nama,
                                ktp_no = x.NoKtp,
                                nopol = x.Nopol,
                                alamat = x.Alamat,
                                credate = x.Credate,
                                latitude = ut.Latitude,
                                longitude = ut.Longitude
                            };

                var listTaskHistory = query.ToList();

                if (listTaskHistory != null && listTaskHistory.Count() > 0)
                {
                    return Json(new
                    {
                        status = statusCode,
                        message = "OK",
                        data = listTaskHistory
                    });
                }
                else
                {
                    statusCode = 404;
                    HttpContext.Response.StatusCode = statusCode;
                    return Json(new
                    {
                        status = statusCode,
                        message = "Data tidak ditemukan!",
                        data = new List<object>().ToArray()
                    });
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                HttpContext.Response.StatusCode = statusCode;
                return Json(new
                {
                    status = statusCode,
                    message = e.Message,
                    data = new List<object>().ToArray()
                });
            }            
        }        

        [Route("ms-api/task/gettasklistsurveyor")]
        [HttpGet]
        [Authorize]
        public ActionResult GetTaskListSurveyor([FromQuery] string nik)
        {
            //if (!Oauth.IsValid(HttpContext)) return ExceptionHandlerUtils.JsonOutput(this, HttpContext, 401, "UnAuthorized");

            //var bodycontent = Utils.getBodyRawAsync(HttpContext.Request);
            //var obj = JsonConvert.DeserializeObject<NikRequest>(bodycontent.Result);
            //string nik = obj.nik;            

            int statusCode = 200;
            try
            {
                var query = from ut in _survDB.UserTasks
                            join tl in _survDB.Tasklists on ut.TaskId equals tl.Id
                            join src in _survDB.SurveyresultClients on ut.TaskId equals src.Taskid into data
                            from x in data.DefaultIfEmpty()
                            where (ut.SurveyorNik == nik && tl.IsPush == 1 && x.Credate == null)
                            select new
                            {
                                task_id = ut.TaskId,
                                nik = ut.SurveyorNik,
                                nama = tl.Nama,
                                alamat = tl.Alamat,
                                nopol = tl.Nopol,
                                credate = tl.Credate,
                                ispush = tl.IsPush,
                                latitude = ut.Latitude,
                                longitude = ut.Longitude
                            };

                var listTasklist = query.ToList();


                //var listTasklist = _survDB.UserTasks
                //    .Join(
                //        _survDB.Tasklists,
                //        a => a.TaskId,
                //        b => b.Id,
                //        (a, b) => new
                //        {
                //            task_id = a.TaskId,
                //            nik = a.SurveyorNik,
                //            nama = b.Nama,
                //            nopol = b.Nopol,
                //            credate = b.Credate,
                //            ispush = b.IsPush,
                //            latitude = a.Latitude,
                //            longitude = a.Longitude
                //        }
                //    )
                //    .Join(
                //        _survDB.SurveyresultClients,
                //        o => o.task_id,
                //        sc => sc.Taskid,
                //        (o, sc) => new
                //        {
                //            task_id = o.task_id,
                //            nik = o.nik,
                //            nama = o.nama,
                //            nopol = o.nopol,
                //            credate = o.credate,
                //            ispush = o.ispush,
                //            latitude = o.latitude,
                //            longitude = o.longitude,
                //            survey_id = sc.Id
                //        }
                //        )
                //    .Where(c => c.nik == nik && c.ispush == 1 && c.survey_id.Equals(Guid.Empty)).ToList();

                if (listTasklist != null && listTasklist.Count() > 0)
                {
                    return Json(new
                    {
                        status = statusCode,
                        message = "OK",
                        data = listTasklist
                    });
                }
                else
                {
                    statusCode = 404;
                    HttpContext.Response.StatusCode = statusCode;
                    return Json(new
                    {
                        status = statusCode,
                        message = "Data tidak ditemukan!",
                        data = new List<object>().ToArray()
                    });
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                HttpContext.Response.StatusCode = statusCode;
                return Json(new
                {
                    status = statusCode,
                    //message = "Terjadi kesalahat saat mengambil data!",
                    message = e.Message,
                    data = new List<object>().ToArray()
                });
            }
        }

        [HttpGet]
        public ActionResult Survey(Guid id)
        {
            return Json(new
            {
                message = "Hello, World!"
            });
        }

        [Route("ms-api/master/getzipcode")]
        [HttpGet]
        public ActionResult ZipCode()
        {
            //if (!Oauth.IsValid(HttpContext)) return ExceptionHandlerUtils.JsonOutput(this, HttpContext, 401, "UnAuthorized");

            int statusCode = 200;
            try
            {
                var data = _survDB.MasterZipCodes.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).Select(a => new { 
                    a.SysZipid,
                    a.Kota,
                    a.Kecamatan,
                    a.Kelurahan,
                    a.Kodepos,
                    a.Areatagih
                }).ToList();

                if (data != null && data.Count() > 0)
                {
                    return Json(new
                    {
                        status = 200,
                        message = "OK",
                        data = data
                    });
                }
                else 
                {
                    statusCode = 404;

                    HttpContext.Response.StatusCode = statusCode;
                    return Json(new
                    {
                        status = statusCode,
                        message = "Data tidak ditemukan!",
                        data = data
                    });
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                HttpContext.Response.StatusCode = statusCode;
                return Json(new
                {
                    status = statusCode,
                    message = e.Message + " " + e.StackTrace,
                    data = new List<Object>().ToArray()
                });
            }
        }

        [Route("ms-api/master/getformupload")]
        [HttpGet]
        public ActionResult FormUpload()
        {
            //if (!Oauth.IsValid(HttpContext)) return ExceptionHandlerUtils.JsonOutput(this, HttpContext, 401, "UnAuthorized");

            int statusCode = 200;
            try
            {
                var frmUpload = _survDB.MasterForms.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).FirstOrDefault();
                List<VwMasterFormUpload> listMasterForm = new List<VwMasterFormUpload>() { };

                if (frmUpload != null)
                {
                    listMasterForm = _survDB.VwMasterFormUploads.Where(a => a.Idform.Value == frmUpload.Id).OrderBy(a => a.Position).ToList();
                }

                if (listMasterForm != null && listMasterForm.Count > 0)
                {
                    return Json(new
                    {
                        status = statusCode,
                        message = "OK",
                        data = listMasterForm
                    });
                }
                else
                {
                    statusCode = 404;
                    HttpContext.Response.StatusCode = statusCode;
                    return Json(new
                    {
                        status = statusCode,
                        message = "Data tidak ditemukan!",
                        data = new List<object>().ToArray()
                    });
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                HttpContext.Response.StatusCode = statusCode;
                return Json(new
                {
                    status = statusCode,
                    message = e.Message,
                    data = new List<object>().ToArray()
                });
            }
        }

        [Route("ms-api/master/getformquisioner")]
        [HttpGet]
        public ActionResult Quisioner()
        {
            //if (!Oauth.IsValid(HttpContext)) return ExceptionHandlerUtils.JsonOutput(this, HttpContext, 401, "UnAuthorized");

            int statusCode = 200;
            try
            {
                var quisioner = _survDB.MasterQuisioners.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).FirstOrDefault();
                List<VwQuisioner> listQuisioner = new List<VwQuisioner>() { };

                if (quisioner != null)
                {
                    //listQuisioner = _survDB.VwQuisioners.Where(a => a.Idquisioner.Value == quisioner.Id).OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).ToList();
                    listQuisioner = _survDB.VwQuisioners.Where(a => a.Idquisioner.Value == quisioner.Id).OrderBy(a => a.Position).ToList();
                }

                if (listQuisioner != null && listQuisioner.Count > 0)
                {
                    return Json(new
                    {
                        status = statusCode,
                        message = "OK",
                        data = listQuisioner
                    });
                }
                else
                {
                    statusCode = 404;
                    HttpContext.Response.StatusCode = statusCode;
                    return Json(new
                    {
                        status = statusCode,
                        message = "Data tidak ditemukan!",
                        data = new List<object>().ToArray()
                    });
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                HttpContext.Response.StatusCode = statusCode;
                return Json(new
                {
                    status = statusCode,
                    message = e.Message + e.StackTrace,
                    data = new List<object>().ToArray()
                });
            }
        }

        [Route("ms-api/master/getcheckingformprocess")]
        [HttpGet]
        public ActionResult Pembaruan()
        {
            //if (!Oauth.IsValid(HttpContext)) return ExceptionHandlerUtils.JsonOutput(this, HttpContext, 401, "UnAuthorized");
            try
            {
                var formUpdate = _survDB.MasterForms.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).FirstOrDefault();
                var formDetailUpdate = _survDB.MasterFormDetails.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).FirstOrDefault();
                var zipcodeUpdate = _survDB.MasterZipCodes.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).FirstOrDefault();
                var quisionerUpdate = _survDB.MasterQuisioners.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).FirstOrDefault();
                var quisionerDetailUpdate = _survDB.MasterPertanyaanQuisioners.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).FirstOrDefault();

                HttpContext.Response.ContentType = "application/json; charset=utf-8";
                return Json(new
                {
                    status = 200,
                    message = "OK",
                    formUpdate = (formUpdate.Moddate.HasValue ? formUpdate.Moddate.Value : formUpdate.Credate.Value),
                    formDetailUpdate = (formDetailUpdate.Moddate.HasValue ? formDetailUpdate.Moddate.Value : formDetailUpdate.Credate.Value),
                    zipcodeUpdate = (zipcodeUpdate.Moddate.HasValue ? zipcodeUpdate.Moddate.Value : zipcodeUpdate.Credate.Value),
                    quisionerUpdate = (quisionerUpdate.Moddate.HasValue ? quisionerUpdate.Moddate.Value : quisionerUpdate.Credate.Value),
                    quisionerDetailUpdate = (quisionerDetailUpdate.Moddate.HasValue ? quisionerDetailUpdate.Moddate.Value : quisionerDetailUpdate.Credate.Value)
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Response.StatusCode = 500;
                return Json(new
                {
                    status = 500,
                    message = "Terjadi kesalahan saat pengambilan data"
                });
            }
        }
    }
}
