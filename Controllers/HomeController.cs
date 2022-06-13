using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SurveyConsole.Models;
using Newtonsoft.Json;
using SurveyConsole.Repositories;
using SurveyConsole.Requests;
using AppResponse = SurveyConsole.Responses;
using SurveyConsole.Libs;
using Microsoft.Extensions.Configuration;
using System.Linq;
using SurveyConsole.Models.Survdbpgsql;
using Microsoft.AspNetCore.Http;
using SurveyConsole.Filters;
using Microsoft.AspNetCore.Hosting;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConsole.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _hosting;
        private readonly IConfiguration _config;
        private AppsSettings _appSettings = new AppsSettings();
        private survdbContext _survDB;
        //private FirebaseApp _fapp;
        //private FirebaseMessaging messaging;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IWebHostEnvironment hosting, survdbContext survDB)
        {
            _logger = logger;
            _hosting = hosting;
            _config = config;
            _config.Bind(_appSettings);
            _survDB = survDB;
        }

        [HttpGet]
        [AuthFilter]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") != null)
            {
                ViewData["UserName"] = HttpContext.Session.GetString("UserName");
                ViewData["BranchName"] = HttpContext.Session.GetString("BranchName");

                var query = from userroles in _survDB.UserRoles
                            join users in _survDB.Users
                                on userroles.UserId equals users.Nik
                            where userroles.CCode == HttpContext.Session.GetString("BranchCode") &&
                            userroles.GroupCode == "BR-MKT"
                            select new User()
                            {
                                Nik = userroles.UserId,
                                Nama = users.Nama
                            };                
                var result = query.ToList();

                ViewBag.User = result;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }

            //return View();
        }

        public IActionResult GetAppl(int page, int limit)
        {
            int statuscode = 200;
            var respose = new Responses.HttpResponse();

            try
            {
                string keyword = HttpContext.Request.Query["keyword"];
                
                ApplRepository ar = new ApplRepository(_survDB);

                respose = ar.GetApplPaginate(HttpContext.Session.GetString("BranchCode"), page, limit, (String.IsNullOrEmpty(keyword) ? null : keyword));

                if (respose.totalData > 0)
                {
                    respose.statuscode = statuscode;
                    respose.message = "OK";
                }
                else
                {
                    statuscode = 404;
                    respose.statuscode = statuscode;
                    respose.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statuscode = 500;
                respose.statuscode = statuscode;
                respose.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = respose.statuscode;
            return Content(JsonConvert.SerializeObject(respose), "application/json");
        }

        [HttpPost]
        [AuthFilter]
        public IActionResult AddAppl([FromBody] FrmAddAppl fac)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();
            List<ValidationError> validationErrors = fac.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                //try
                //{
                //    ApplRepository ar = new ApplRepository(_survDB);
                //    if (ModelState.IsValid)
                //    {
                //        if (ar.CreateAppl(HttpContext.Session.GetString("BranchCode"), HttpContext.Session.GetString("User"), fac))
                //        {
                //            hr.statuscode = 201;
                //            hr.message = "Data berhasil disimpan!";
                //        }
                //        else
                //        {
                //            hr.statuscode = 422;
                //            hr.message = "Gagal menyimpan data!";
                //        }
                //    }                    
                //}
                //catch (Exception e)
                //{
                //    hr.statuscode = 500;
                //    hr.message = "Terjadi kesalahan saat menyimpan data!" + e.Message;
                //}

                Tasklist tl = new Tasklist();

                //UserTask ut = new UserTask();

                tl.Id = Guid.NewGuid();

                //ut.Id = Guid.NewGuid();
                //ut.TaskId = tl.Id;

                //tl.UserTasks 

                
                tl.Nama = fac.CustName;
                tl.Nik = fac.CustNik;
                tl.Nopol = fac.UnitId;
                tl.Notelp = fac.Phone;
                tl.Alamat = fac.Address;
                tl.IsPush = 0;
                tl.Creby = HttpContext.Session.GetString("User");
                tl.Ccode = HttpContext.Session.GetString("BranchCode");


                _survDB.Tasklists.Add(tl);               
                Boolean result_tl = _survDB.SaveChanges() > 0;

                _survDB.Dispose();
                if (result_tl == true)
                {
                    hr.statuscode = 201;
                    hr.message = "Data berhasil disimpan!";
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        [HttpDelete]
        public IActionResult DeleteAppl(Guid id)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            try
            {
                ApplRepository ar = new ApplRepository(_survDB);

                if (ar.DeleteAppl(id))
                {
                    hr.statuscode = 200;
                    hr.message = "Data berhasil dihapus!";
                }
                else
                {
                    hr.statuscode = 422;
                    hr.message = "Gagal menghapus data!";
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                hr.statuscode = 500;
                hr.message = "Terjadi kesalahan saat menghapus data!";
            }

            HttpContext.Response.StatusCode = hr.statuscode;

            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        [HttpPost]
        public IActionResult SendNotification(FrmSendNotification fn)
        {
            //fc = new FcmClient(_appSettings.CustomConfig.GoogleCredential);
            JsonResult result;

            if (String.IsNullOrEmpty(fn.destinationToken))
            {
                // Default destination token
                fn.destinationToken = _appSettings.CustomConfig.DefaultFCMDestinationToken;
                
            }

            Dictionary<String, String> data = new Dictionary<String, String>() { };
            data.Add("click_action", "FLUTTER_NOTIFICATION_CLICK");
            data.Add("body", "Data survey baru telah tersedia atas nama Test Notif");
            data.Add("title", "Mobile Survey");

            try
            {
                String response = FcmClient.SendNotification(fn.destinationToken, data, _appSettings.CustomConfig.GoogleCredential);
                if(!String.IsNullOrEmpty(response))
                {
                    result = Json(new {
                        message = "OK"
                    });
                }
                else
                {
                    throw new Exception("NULL RESPONSE");
                }
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, e.Message);
                HttpContext.Response.StatusCode = 500;
                result = Json(new
                {
                    message = "FAILED"
                });
            }

            return result;
        }

        [HttpPost]
        [AuthFilter]
        public async Task<IActionResult> PushNotif([FromBody] FrmAddApplSurvey facs)
        {
            var query = _survDB.Tasklists.Select(a => new
            {
                a.Nama,
                a.Id
            }).Where(a => a.Id.Equals(facs.TaskId));
            var result = query.ToList();
            string custName = "";
            foreach (var item in result)
            {
                custName = item.Nama;
            }


            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("authorization", "Basic ZDk4NTdlMjAtOWJiMi00NTFkLWEyNDctMjc1ZTZlOWNjNzVi");

            var obj = new
            {
                app_id = "71884f36-1ee8-4bac-82e8-415929d76017",
                headings = new { id = "New Task List - Survey" },
                contents = new { id = "Data survey baru telah tersedia atas nama!" + custName },
                //include_external_user_ids = new string[] { "123456789" },
                included_segments = new string[] { "Subscribed Users" }
            };
            var param = JsonConvert.SerializeObject(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;

            /*------------------------------------------------------------------------*/

            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();
            List<ValidationError> validationErrors = facs.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                try
                {
                    ApplRepository ar = new ApplRepository(_survDB);

                    if (ar.CreateApplSurvey(facs))
                    {
                        try
                        {
                            using (var writer = request.GetRequestStream())
                            {
                                writer.Write(byteArray, 0, byteArray.Length);
                            }

                            using (var response = request.GetResponse() as HttpWebResponse)
                            {
                                using (var reader = new StreamReader(response.GetResponseStream()))
                                {
                                    responseContent = reader.ReadToEnd();
                                }
                            }
                        }
                        catch (WebException ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                            System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                        }

                        hr.statuscode = 201;
                        hr.message = "Data berhasil disimpan!\n";
                    }
                    else
                    {
                        hr.statuscode = 422;
                        hr.message = "Gagal menyimpan data!";
                    }
                }
                catch (Exception e)
                {
                    hr.statuscode = 500;
                    hr.message = "Terjadi kesalahan saat menyimpan data!" + e.Message;
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            HttpContext.Response.StatusCode = hr.statuscode;
            return Json(new
            {
                message = hr
            });                                       
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
    
}
