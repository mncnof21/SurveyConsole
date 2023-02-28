using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SurveyConsole.Models;
using SurveyConsole.Models.FACEDB;
using SurveyConsole.Libs;
using SurveyConsole.Models.Survdbpgsql;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System;
using System.Data;
using Newtonsoft.Json;

namespace SurveyConsole.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private IWebHostEnvironment _hosting;
        private readonly IConfiguration _config;
        private AppsSettings _appSettings = new AppsSettings();
        private FACEDBContext _facedb;

        public DashboardController(ILogger<DashboardController> logger, IConfiguration config, IWebHostEnvironment hosting, FACEDBContext facedb)
        {
            _logger = logger;
            _hosting = hosting;
            _config = config;
            _config.Bind(_appSettings);
            _facedb = facedb;
        }
        public IActionResult Index()
        {
            ViewData VD = new ViewData();
            DataTable ds = new DataTable();
            DBUtils db = new DBUtils(_facedb);
            string query = @"select 
                            'JAN' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=1 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=1 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'FEB' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=2 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=2 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'MAR' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=3 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=3 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'APR' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=4 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=4 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'MAY' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=5 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=5 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'JUN' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=6 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=6 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'JUL' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=7 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=7 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'AUG' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=8 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=8 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'SEP' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=9 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=9 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'OCT' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=10 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=10 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'NOV' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=11 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=11 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH
                            UNION ALL
                            select 
                            'DEC' AS BULAN, 
                            (select COUNT(1) from SIAP_DM where MONTH(cre_date)=12 and year(cre_date)= year(GETDATE())) AS A_DANA_MOBIL,
                            (select COUNT(1) from SIAP_DR where MONTH(cre_date)=12 and year(cre_date)= year(GETDATE())) AS A_DANA_RUMAH";

            ds = db.GetDataTable(query, false);

            VD.data = ds;
            ViewBag.Data = JsonConvert.SerializeObject(VD.data);
            return View();
        }
    }
}
