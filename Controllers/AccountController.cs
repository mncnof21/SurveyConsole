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
using System.Linq;

namespace SurveyConsole.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _config;
        private AppsSettings _appSettings = new AppsSettings();
        private survdbContext _survDB;
        private Auth _auth;

        public AccountController(ILogger<AuthController> logger, IConfiguration config, survdbContext survDB)
        {
            _logger = logger;
            _config = config;
            _config.Bind(_appSettings);
            _survDB = survDB;
            _auth = new Auth(_survDB, _appSettings);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }                

        public ActionResult GetBranch(string value)
        {
            var query = _survDB.MasterBranches
                .Join(
                _survDB.UserRoles,
                a => a.CCode,
                b => b.CCode,
                (a, b) => new {
                    UserId = b.UserId,
                    CCode = b.CCode,
                    CName = a.CName
                }
                ).Where(c => c.UserId == value);

            var result = query.ToList();
            
            string output = "<option value=''>- Select Branch -</option>";
            foreach (var data in result)
            {
                output += "<option value='" + data.CCode + "'>" + data.CName + "</option>";
            }

            return Json(output);
        }        

        //[HttpPost]
        //[IgnoreAntiforgeryToken]
        //public ActionResult Login(FrmLogin frmlogin)
        //{
        //    int statusCode = 200;
        //    try {
        //        var errors = frmlogin.Validate();
        //        if (errors != null && errors.Count > 0)
        //        {
        //            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //            {
        //                statusCode = 422;
        //                HttpContext.Response.StatusCode = statusCode;
        //                return Json(new
        //                {
        //                    status = statusCode,
        //                    message = "Validation error"
        //                });
        //            }
        //            else
        //            {
        //                TempData["errors"] = errors;
        //                return RedirectToAction("Login", "Auth");
        //            }
        //        }
        //        else
        //        {
        //            List<String> jwt = _auth.checkLogin(frmlogin, HttpContext);
        //            if (jwt != null && jwt.Count() > 0)
        //            {                        
        //                statusCode = 200;
        //                HttpContext.Response.StatusCode = statusCode;
        //                var query = (from a in _survDB.UserRoles
        //                                join b in _survDB.Users on a.UserId equals b.Nik
        //                                join c in _survDB.MasterBranches on a.CCode equals c.CCode
        //                                where a.UserId == frmlogin.nik && a.CCode == frmlogin.branch
        //                                select new
        //                                {
        //                                    UserId = a.UserId,
        //                                    GroupCode = a.GroupCode,
        //                                    BranchName = c.CName,
        //                                    UserName = b.Nama
        //                                }).ToList();

        //                foreach (var data in query)
        //                {
        //                    HttpContext.Session.SetString("BranchName", data.BranchName);
        //                    HttpContext.Session.SetString("UserName", data.UserName);
        //                    HttpContext.Session.SetString("GroupCode", data.GroupCode);
        //                }
        //                HttpContext.Session.SetString("User", frmlogin.nik);
        //                HttpContext.Session.SetString("BranchCode", frmlogin.branch);

        //                return RedirectToAction("Index", "Home");                                              
        //            }
        //            else
        //            {
        //                statusCode = 401;
        //                HttpContext.Response.StatusCode = statusCode;
        //                return Json(new
        //                {
        //                    status = statusCode,
        //                    message = "Unauthorized"
        //                });
        //            }
        //        }                
        //    }
        //    catch (Exception e)
        //    {
        //        statusCode = 500;
        //        HttpContext.Response.StatusCode = statusCode;
        //        return Json(new
        //        {
        //            status = statusCode,
        //            message = e.Message + " " + e.StackTrace
        //        });
        //    }
        //}

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public ActionResult LoginAccount(FrmLogin frmlogin)
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
                        String errorMessage = "";
                        foreach(var error in errors)
                        {
                            errorMessage = errorMessage + " " + error.ErrorMessage;
                        }
                        TempData["alert"] = errorMessage;
                        return RedirectToAction("Login", "Auth");
                    }
                }
                else
                {
                    List<String> jwt = _auth.checkLogin(frmlogin, HttpContext);
                    if (jwt != null && jwt.Count() > 0)
                    {
                        statusCode = 200;
                        HttpContext.Response.StatusCode = statusCode;
                                               
                        var query = (from a in _survDB.UserRoles
                                        join b in _survDB.Users on a.UserId equals b.Nik
                                        join c in _survDB.MasterBranches on a.CCode equals c.CCode
                                        where a.UserId == frmlogin.nik && a.CCode == frmlogin.branch
                                        select new
                                        {
                                            UserId = a.UserId,
                                            GroupCode = a.GroupCode,
                                            BranchName = c.CName,
                                            UserName = b.Nama
                                        }).ToList();

                        foreach (var data in query)
                        {
                            HttpContext.Session.SetString("BranchName", data.BranchName);
                            HttpContext.Session.SetString("UserName", data.UserName);
                            HttpContext.Session.SetString("GroupCode", data.GroupCode);
                        }
                        HttpContext.Session.SetString("User", frmlogin.nik);
                        HttpContext.Session.SetString("BranchCode", frmlogin.branch);

                        return RedirectToAction("Index", "Home");
                        
                    }
                    else
                    {
                        statusCode = 401;
                        HttpContext.Response.StatusCode = statusCode;
                        //TempData["alert"] = "Unauthorized with a JWT Token";
                        TempData["alert"] = "Incorrect user_id (nik) or password.";
                        return RedirectToAction("Login", "Auth");
                    }
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                HttpContext.Response.StatusCode = statusCode;
                TempData["alert"] = e.Message + " | " + e.StackTrace;
                return RedirectToAction("Login", "Auth");                
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
