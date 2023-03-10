using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SurveyConsole.Models;
using SurveyConsole.Models.FACEDB;
using SurveyConsole.Models.Survdbpgsql;
using SurveyConsole.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using AppResponse = SurveyConsole.Responses;
using SurveyConsole.Requests;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SurveyConsole.Libs;
using Microsoft.EntityFrameworkCore;

namespace SurveyConsole.Controllers
{
    public class SiapController : Controller
    {
        private ILogger<SiapController> _logger;
        private FACEDBContext _facedb;
        private survdbContext _survdb;
        private SiapRepository _siapRepository;
        private IConfiguration _config;
        private AppsSettings _appSettings = new AppsSettings();
        private IWebHostEnvironment _hostingEnvironment;

        public SiapController(ILogger<SiapController> logger, IConfiguration config, IWebHostEnvironment hostingEnvironment, FACEDBContext facedb, survdbContext survdb)
        {
            _logger = logger;
            _config = config;
            _config.Bind(_appSettings);
            _facedb = facedb;
            _survdb = survdb;
            _hostingEnvironment = hostingEnvironment;
            _siapRepository = new SiapRepository(_facedb);
        }

        // GET: SiapController
        public ActionResult Index()
        {
            return RedirectToAction("DanaRumah", "Siap");
        }
        

        public ActionResult DanaRumah()
        {
            return View();
        }

        public ActionResult GetListDanaRumah(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaRumahPaginate(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaRumahNew(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaRumahPaginateNew(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaRumahOnprogress(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaRumahPaginateOnprogress(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaRumahGolive(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaRumahPaginateGolive(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaRumahTerminate(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaRumahPaginateTerminate(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaRumahReject(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaRumahPaginateReject(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult DanaMobil()
        {
            return View();
        }

        public ActionResult GetListDanaMobil(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaMobilPaginate(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaMobilNew(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaMobilPaginateNew(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaMobilOnprogress(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaMobilPaginateOnprogress(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaMobilGolive(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaMobilPaginateGolive(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaMobilTerminate(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaMobilPaginateTerminate(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult GetListDanaMobilReject(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var response = new Responses.HttpResponse();

            try
            {
                response = _siapRepository.GetDanaMobilPaginateReject(page, limit, keyword);

                if (response.totalData > 0)
                {
                    response.statuscode = statusCode;
                    response.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    response.statuscode = statusCode;
                    response.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                response.statuscode = statusCode;
                response.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = response.statuscode;
            return Json(response);
        }

        public ActionResult Details(long id)
        {
            string type = HttpContext.Request.Query["type"];
            List<string> fintypes = new List<string>() { "mobil", "rumah" };

            if(!fintypes.Contains(type))
            {
                return RedirectToAction("Index", "Siap");
            }

            if (type == "mobil")
            {
                var datax = (from dm in _facedb.SiapDms
                             join m in _facedb.MmerkViews on EF.Functions.Collate(dm.CarBrand, "SQL_Latin1_General_CP1_CS_AS") equals m.MerkCode
                             join t in _facedb.MtypeViews on EF.Functions.Collate(dm.CarType, "SQL_Latin1_General_CP1_CS_AS") equals t.TypeCode
                             join md in _facedb.MmodelViews on EF.Functions.Collate(dm.CarModel, "SQL_Latin1_General_CP1_CS_AS") equals md.ModelCode
                             where dm.EntryId == id
                             select new { merkdesc = m.Description, typedesc = t.Description, modeldesc = md.Description }).ToList();
                string unitdesc = "";

                foreach (var dtunit in datax)
                {
                    unitdesc = dtunit.merkdesc + "/ " + dtunit.typedesc + "/ " + dtunit.modeldesc;
                }

                ViewBag.unit = unitdesc;

                var querybranchall = _survdb.MasterBranches;
                var resultbranchall = querybranchall.ToList();

                ViewBag.branch = resultbranchall;

                var data = _facedb.SiapDms.Where(a => a.EntryId == id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();

                if(data == null)
                {
                    return RedirectToAction("DanaMobil", "Siap");
                }

                ViewData["title"] = "Motion Credit Dana Mobil Detail";
                ViewData["module"] = type;
                ViewData["content"] = "~/Views/Siap/_DanaMobilDetail.cshtml";
                ViewBag.detail = data;
            }
            else if(type == "rumah")
            {
                var data = _facedb.SiapDrs.Where(a => a.EntryId == id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();

                if (data == null)
                {
                    return RedirectToAction("DanaRumah", "Siap");
                }

                ViewData["title"] = "Motion Credit Dana Rumah Detail";
                ViewData["module"] = type;
                ViewData["content"] = "~/Views/Siap/_DanaRumahDetail.cshtml";
                ViewBag.detail = data;
            }

            TempData["SiapUrl"] = _appSettings.SIAPUrl;
            return View();
        }

        // itrack-submit
        [HttpPost]
        public async Task<ActionResult> SubmitItrack([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                //using (var client = new HttpClient())
                //{
                // auth
                //var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                //var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                //client.DefaultRequestHeaders.Authorization = header;

                //// content data
                //var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                //StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                //client.BaseAddress = new Uri("https://api.motioncredit.id/");

                //using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                //{
                //    var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                //    responseMessage.EnsureSuccessStatusCode();

                //    if(responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                //    {

                DBUtils db = new DBUtils(_facedb);
                string query = "exec DIGI_TO_ITRACK '"+ fusr.application_id + "','"+ HttpContext.Session.GetString("User") +"'";

                if (db.ExecuteNonQuery(query) == true)
                {
                    var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                    if (upd != null)
                    {
                        upd.MfinState = fusr.status;
                        _facedb.SaveChanges();
                        hr.statuscode = 200;
                        hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                    }
                }                            
                    //    }
                    //}                                                                                                                                                                               
                //}                             
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }            

            _facedb.Dispose();            

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // survey-onprogress
        [HttpPost]
        public async Task<ActionResult> SurveyOnprogress([FromBody] FrmUpdateStatusSurveyDataReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data

                    FrmUpdateStatusSurveyMCReq frmUpdateStatusSurveyMCReq = new FrmUpdateStatusSurveyMCReq();
                    frmUpdateStatusSurveyMCReq.application_id = fusr.application_id;
                    frmUpdateStatusSurveyMCReq.status = fusr.status;
                    frmUpdateStatusSurveyMCReq.wop = fusr.wop;
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(frmUpdateStatusSurveyMCReq));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                upd.Wop = fusr.wop;
                                _facedb.SaveChanges();

                                Tasklist tasklist= new Tasklist();
                                tasklist.Id = Guid.NewGuid();

                                tasklist.Nama = fusr.fullname;
                                tasklist.Nik = fusr.nik;
                                tasklist.Nopol = fusr.policeno;
                                tasklist.Notelp = fusr.phone;
                                tasklist.Alamat = fusr.address;
                                tasklist.IsPush = 0;
                                tasklist.Creby = "motion-credit";
                                tasklist.Ccode = fusr.branch;
                                _survdb.Tasklists.Add(tasklist);

                                Boolean result_tl = _survdb.SaveChanges() > 0;

                                _survdb.Dispose();
                                if (result_tl == true)
                                {
                                    hr.statuscode = 200;
                                    hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                                }                                    
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // survey-done
        [HttpPost]
        public async Task<ActionResult> SurveyDone([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // core-submit
        [HttpPost]
        public async Task<ActionResult> SubmitCore([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                
                var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                if (upd != null)
                {
                    upd.MfinState = fusr.status;                    
                    _facedb.SaveChanges();
                    hr.statuscode = 200;
                    hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                }                
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // approval-approved
        [HttpPost]
        public async Task<ActionResult> CommitteeApproved([FromBody] FrmUpdateStatusApprovedReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr).Replace("[","").Replace("]",""));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                upd.ContractNo = fusr.contract_number;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // approval-reject
        [HttpPost]
        public async Task<ActionResult> CommitteeReject([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // approval-cancel
        [HttpPost]
        public async Task<ActionResult> CommitteeCancel([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // golive-active
        [HttpPost]
        public async Task<ActionResult> GoliveActive([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // golive-disburse
        [HttpPost]
        public async Task<ActionResult> GoliveDisburse([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // loan-terminate
        [HttpPost]
        public async Task<ActionResult> LoanTerminate([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // survey-onprogress rumah
        [HttpPost]
        public async Task<ActionResult> SurveyOnprogressRumah([FromBody] FrmUpdateStatusSurveyDataReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                upd.Wop = fusr.wop;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // survey-done rumah
        [HttpPost]
        public async Task<ActionResult> SurveyDoneRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // appraisal-unpaid rumah
        [HttpPost]
        public async Task<ActionResult> AppraisalUnpaidRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // appraisal-paid rumah
        [HttpPost]
        public async Task<ActionResult> AppraisalPaidRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // appraisal-onprogress rumah
        [HttpPost]
        public async Task<ActionResult> AppraisalOnprogressRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // appraisal-done rumah
        [HttpPost]
        public async Task<ActionResult> AppraisalDoneRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // core-submit rumah
        [HttpPost]
        public async Task<ActionResult> SubmitCoreRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                //using (var client = new HttpClient())
                //{
                //    // auth
                //    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                //    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                //    client.DefaultRequestHeaders.Authorization = header;

                //    // content data
                //    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                //    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                //    client.BaseAddress = new Uri("https://api.motioncredit.id/");

                //    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                //    {
                //        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                //        responseMessage.EnsureSuccessStatusCode();

                //        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                //        {
                var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                if (upd != null)
                {
                    upd.MfinState = fusr.status;
                    _facedb.SaveChanges();
                    hr.statuscode = 200;
                    hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                }
                //        }
                //    }
                //}
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // approval-approved rumah
        [HttpPost]
        public async Task<ActionResult> CommitteeApprovedRumah([FromBody] FrmUpdateStatusApprovedReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr).Replace("[", "").Replace("]", ""));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                upd.ContractNo = fusr.contract_number;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }
        
        // approval-reject rumah
        [HttpPost]
        public async Task<ActionResult> CommitteeRejectRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // approval-cancel rumah
        [HttpPost]
        public async Task<ActionResult> CommitteeCancelRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // sign-onprogress rumah
        [HttpPost]
        public async Task<ActionResult> SignOnprogressRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // sign-done rumah
        [HttpPost]
        public async Task<ActionResult> SignDoneRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // golive-active rumah
        [HttpPost]
        public async Task<ActionResult> GoliveActiveRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // golive-disburse rumah
        [HttpPost]
        public async Task<ActionResult> GoliveDisburseRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        // loan-terminate rumah
        [HttpPost]
        public async Task<ActionResult> LoanTerminateRumah([FromBody] FrmUpdateStatusReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        [HttpPost]
        public async Task<ActionResult> RejectDanaMobil([FromBody] FrmUpdateStatusAdmRejectReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danamobil/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDms.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                upd.ReasonReject = fusr.reason;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        [HttpPost]
        public async Task<ActionResult> RejectDanaRumah([FromBody] FrmUpdateStatusAdmRejectReq fusr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fusr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                using (var client = new HttpClient())
                {
                    // auth
                    var byteArray = Encoding.ASCII.GetBytes("mfin_callback:fwzcuXn4ZVQmMpUQ4gvGxc6KW7xFfWxZ");
                    var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Authorization = header;

                    // content data
                    var json = Chipher.Encryptword(JsonConvert.SerializeObject(fusr));
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    client.BaseAddress = new Uri(_config["MotionUrl"]);

                    using (HttpResponseMessage responseMessage = await client.PostAsync("callback/mfin/danarumah/status", httpContent))
                    {
                        var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                        responseMessage.EnsureSuccessStatusCode();

                        if (responseMessage.StatusCode != System.Net.HttpStatusCode.BadRequest)
                        {
                            var upd = _facedb.SiapDrs.Where(a => a.SiapId == fusr.application_id).OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).FirstOrDefault();
                            if (upd != null)
                            {
                                upd.MfinState = fusr.status;
                                upd.ReasonReject = fusr.reason;
                                _facedb.SaveChanges();
                                hr.statuscode = 200;
                                hr.message = "Update Status (" + fusr.status + ") berhasil disimpan!";
                            }
                        }
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _facedb.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        protected override void Dispose(bool disposing)
        {
            _facedb.Dispose();
            base.Dispose(disposing);
        }
    }
}
