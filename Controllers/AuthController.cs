using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SurveyConsole.Libs;
using SurveyConsole.Models;
using SurveyConsole.Models.Survdbpgsql;
using SurveyConsole.Requests;
using System;
using System.Collections.Generic;
using AppResponse = SurveyConsole.Responses;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SurveyConsole.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _config;
        private AppsSettings _appSettings = new AppsSettings();
        private survdbContext _survDB;
        private Auth _auth;
        //private HttpContext _http;
        //private UserRepository _userRepo;

        public AuthController(ILogger<AuthController> logger, IConfiguration config, survdbContext survDB)
        {
            _logger = logger;
            _config = config;
            _config.Bind(_appSettings);
            _survDB = survDB;
            _auth = new Auth(_survDB, _appSettings);
        }

        public ActionResult GetBranch()
        {
            List<MasterBranch> branchList = new List<MasterBranch>();
            branchList = _survDB.MasterBranches.ToList();
            return Json(branchList);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SubmitChangePassword([FromBody] FrmChangePasswordReq fcpr)
        {
            AppResponse.HttpResponse hr = new AppResponse.HttpResponse();

            List<ValidationError> validationErrors = fcpr.Validate();

            if (validationErrors == null || validationErrors.Count <= 0)
            {                
                if(fcpr.password != fcpr.confirmpassword)
                {
                    hr.statuscode = 400;
                    hr.message = "The password confirmation does not match!";
                }
                else
                {
                    string confirmpass = BCrypt.Net.BCrypt.HashPassword(fcpr.password);
                    var upd = _survDB.UserAuths.Where(a => a.Nik == HttpContext.Session.GetString("User")).FirstOrDefault();
                    if (upd != null)
                    {
                        upd.Password = confirmpass;
                        _survDB.SaveChanges();
                        hr.statuscode = 200;
                        hr.message = "Password changed successfully.";
                    }
                }
            }
            else
            {
                hr.statuscode = 400;
                hr.message = "Data tidak valid!";
                hr.errors = validationErrors;
            }

            _survDB.Dispose();

            HttpContext.Response.StatusCode = hr.statuscode;
            return Content(JsonConvert.SerializeObject(hr), "application/json");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }                

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

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult CheckJWT()
        {
            if (!Oauth.IsValid(HttpContext)) return Json(new { 
                status = 401,
                message = "Unauthorized"
            });

            return Json(new
            {
                status = 200,
                message = "OK"
            });
        }

        public IActionResult PasswordGenerator(String id)
        {
            return Content(BCrypt.Net.BCrypt.HashPassword(id));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
