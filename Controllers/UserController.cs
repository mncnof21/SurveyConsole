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
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConsole.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _hosting;
        private readonly IConfiguration _config;
        private AppsSettings _appSettings = new AppsSettings();
        private survdbContext _survDB;

        public UserController(ILogger<HomeController> logger, IConfiguration config, IWebHostEnvironment hosting, survdbContext survDB)
        {
            _logger = logger;
            _hosting = hosting;
            _config = config;
            _config.Bind(_appSettings);
            _survDB = survDB;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public ActionResult GetMasterUser(int page, int limit)
        {
            int statuscode = 200;
            var respose = new Responses.HttpResponse();

            try
            {
                string keyword = HttpContext.Request.Query["keyword"];

                UserRepository usr = new UserRepository(_survDB, _appSettings);

                respose = usr.GetMasterUserPaginate(page, limit, (String.IsNullOrEmpty(keyword) ? null : keyword));

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

        public ActionResult Edit()
        {
            string nik = HttpContext.Request.Query["id"];

            User user = _survDB.Users.Where(a => a.Nik.Contains(nik)).FirstOrDefault();
            UserRole userrole2 = _survDB.UserRoles.Where(a => a.UserId.Contains(nik)).FirstOrDefault();

            var queryuserrole = from usr in _survDB.Users
                        join usrrole in _survDB.UserRoles
                        on usr.Nik equals usrrole.UserId
                        join mstbranch in _survDB.MasterBranches
                        on usrrole.CCode equals mstbranch.CCode
                        where usr.Nik == nik
                        select new
                        {
                            Id = usrrole.Id,
                            UserId = usr.Nik,
                            Nama = usr.Nama,
                            GroupUser = usrrole.GroupCode,
                            Branch = mstbranch.CName,
                            Credate = usrrole.Credate
                        };
            var userrole = queryuserrole.ToList();

            var querybranchall = from masterbranch in _survDB.MasterBranches
                                 select new MasterBranch()
                                 {
                                     CCode = masterbranch.CCode,
                                     CName = masterbranch.CName
                                 };
            var resultbranchall = querybranchall.ToList();

            ViewBag.Branch = resultbranchall;
            
            ViewBag.user = user;
            ViewBag.userrole2 = userrole2;
            ViewBag.userrole = userrole;
            return View();
        }

        public ActionResult Add()
        {
            var querybranchall = from masterbranch in _survDB.MasterBranches
                                 select new MasterBranch()
                                 {
                                     CCode = masterbranch.CCode,
                                     CName = masterbranch.CName
                                 };
            var resultbranchall = querybranchall.ToList();

            ViewBag.Branch = resultbranchall;
            return View();
        }

        public IActionResult GetUserBranch(int page, int limit)
        {
            int statuscode = 200;
            var respose = new Responses.HttpResponse();

            try
            {
                string keyword = HttpContext.Request.Query["keyword"];

                UserRepository usr = new UserRepository(_survDB, _appSettings);

                respose = usr.GetMasterUserBranch(page, limit, (String.IsNullOrEmpty(keyword) ? null : keyword));

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

        [HttpDelete]
        public IActionResult DeleteBranchUser(Guid id)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            try
            {
                UserRepository usr = new UserRepository(_survDB, _appSettings);

                if (usr.DeleteBranchUser(id))
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

        [HttpDelete]
        public IActionResult DeleteUser(Guid id)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            try
            {
                UserRepository usr = new UserRepository(_survDB, _appSettings);

                if (usr.DeleteUser(id))
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
        public IActionResult AddMasterUserRole([FromBody] FrmAddMasterUser famu)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();
            List<ValidationError> validationErrors = famu.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                User usr = new User();
                UserAuth usrauth = new UserAuth();
                UserRole usrrole = new UserRole();           

                usr.Id = Guid.NewGuid();
                usr.Nik = famu.Nik;
                usr.Nama = famu.Nama;
                usr.Creby = HttpContext.Session.GetString("User");

                string pass = BCrypt.Net.BCrypt.HashPassword(famu.Password);
                usrauth.Id = Guid.NewGuid();
                usrauth.Nik = famu.Nik;
                usrauth.Password = pass;
                usrauth.Creby = HttpContext.Session.GetString("User");

                usrrole.Id = Guid.NewGuid();
                usrrole.UserId = famu.Nik;
                usrrole.CCode = famu.CCode;
                usrrole.GroupCode = famu.GroupCode;
                usrrole.Creby = HttpContext.Session.GetString("User");

                var checkUser = _survDB.Users.Where(a => a.Nik == famu.Nik).FirstOrDefault();
                if(checkUser == null)
                {
                    _survDB.Users.Add(usr);
                }
                else
                {
                    checkUser.Nama = famu.Nama;
                }

                var checkUserAuth = _survDB.UserAuths.Where(a => a.Nik == famu.Nik).FirstOrDefault();
                if(checkUserAuth == null)
                {
                    _survDB.UserAuths.Add(usrauth);
                }

                var checkUserRole = _survDB.UserRoles.Where(a => a.UserId == famu.Nik).FirstOrDefault();
                if (checkUserRole == null)
                {
                    _survDB.UserRoles.Add(usrrole);
                }
                else
                {
                    _survDB.UserRoles.Add(usrrole);
                }                

                Boolean result_usr = _survDB.SaveChanges() > 0;

                _survDB.Dispose();
                if (result_usr == true)
                {
                    hr.statuscode = 201;
                    hr.message = "Data berhasil disimpan!";
                }
            }
            else
            {
                hr.errors = validationErrors;
                hr.statuscode = 200;
                hr.message = string.Join(",", validationErrors.Select(a => a.ErrorMessage));
            }

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        [HttpPost]
        public IActionResult UpdMasterUserRole([FromBody] FrmUpdMasterUser famu)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();
            List<ValidationError> validationErrors = famu.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                User usr = new User();
                UserAuth usrauth = new UserAuth();
                UserRole usrrole = new UserRole();

                usr.Id = Guid.NewGuid();
                usr.Nik = famu.Nik;
                usr.Nama = famu.Nama;
                usr.Creby = HttpContext.Session.GetString("User");

                string pass = BCrypt.Net.BCrypt.HashPassword(famu.Password);
                usrauth.Id = Guid.NewGuid();
                usrauth.Nik = famu.Nik;
                usrauth.Password = pass;
                usrauth.Creby = HttpContext.Session.GetString("User");

                usrrole.Id = Guid.NewGuid();
                usrrole.UserId = famu.Nik;
                usrrole.CCode = famu.CCode;
                usrrole.GroupCode = famu.GroupCode;
                usrrole.Creby = HttpContext.Session.GetString("User");

                var checkUser = _survDB.Users.Where(a => a.Nik == famu.Nik).FirstOrDefault();
                if (checkUser == null)
                {
                    _survDB.Users.Add(usr);
                }
                else
                {
                    checkUser.Nama = famu.Nama;
                }

                var checkUserAuth = _survDB.UserAuths.Where(a => a.Nik == famu.Nik).FirstOrDefault();
                if (checkUserAuth == null)
                {
                    _survDB.UserAuths.Add(usrauth);
                }

                var checkUserRole = _survDB.UserRoles.Where(a => a.UserId == famu.Nik).FirstOrDefault();
                if (checkUserRole == null)
                {
                    _survDB.UserRoles.Add(usrrole);
                }
                else
                {
                    _survDB.UserRoles.Add(usrrole);
                }

                Boolean result_usr = _survDB.SaveChanges() > 0;

                _survDB.Dispose();
                if (result_usr == true)
                {
                    hr.statuscode = 201;
                    hr.message = "Data berhasil disimpan!";
                }
            }
            else
            {
                hr.errors = validationErrors;
                hr.statuscode = 200;
                hr.message = string.Join(",", validationErrors.Select(a => a.ErrorMessage));
            }

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        [HttpPost]
        public IActionResult ChangePassword([FromBody] FrmChangePassword fcp)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();
            List<ValidationError> validationErrors = fcp.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                string pass = BCrypt.Net.BCrypt.HashPassword(fcp.Password);

                var upd = _survDB.UserAuths.SingleOrDefault(a => a.Nik.Equals(fcp.Nik));
                if (upd != null)
                {
                    upd.Password = pass;
                }

                Boolean result_usr = _survDB.SaveChanges() > 0;

                _survDB.Dispose();
                if (result_usr == true)
                {
                    hr.statuscode = 201;
                    hr.message = "Ganti Password berhasil disimpan!";
                }
            }
            else
            {
                hr.errors = validationErrors;
                hr.statuscode = 200;
                hr.message = string.Join(",", validationErrors.Select(a => a.ErrorMessage));
            }

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        [HttpPost]
        public IActionResult ResetPassword([FromBody] FrmChangePassword fcp)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();
            List<ValidationError> validationErrors = fcp.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {
                string pass = BCrypt.Net.BCrypt.HashPassword(fcp.Password);

                var upd = _survDB.UserAuths.SingleOrDefault(a => a.Nik.Equals(fcp.Nik));
                if (upd != null)
                {
                    upd.Password = pass;
                }

                Boolean result_usr = _survDB.SaveChanges() > 0;

                _survDB.Dispose();
                if (result_usr == true)
                {
                    hr.statuscode = 201;
                    hr.message = "Reset berhasil disimpan!";
                }
            }
            else
            {
                hr.errors = validationErrors;
                hr.statuscode = 200;
                hr.message = string.Join(",", validationErrors.Select(a => a.ErrorMessage));
            }

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }
    }
}
