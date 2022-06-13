using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SurveyConsole.Models;
using SurveyConsole.Models.Survdbpgsql;
using SurveyConsole.Libs;
using SurveyConsole.Repositories;
using SurveyConsole.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SurveyConsole.Controllers
{
    public class ResultController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private AppsSettings _appSettings = new AppsSettings();
        private survdbContext _survDB;
        private IWebHostEnvironment _hostingEnvironment;

        public ResultController(ILogger<HomeController> logger, IConfiguration config, IWebHostEnvironment hostingEnvironment, survdbContext survDB)
        {
            _logger = logger;
            _config = config;
            _config.Bind(_appSettings);
            _survDB = survDB;
            _hostingEnvironment = hostingEnvironment;
            SurveyRepository.db = _survDB;
            SurveyRepository.hostingEnv = _hostingEnvironment;
        }

        public iTextSharp.text.Document AddImageToPDF(String[] imagePaths, String outputPDF)
        {
            FileStream fs = new FileStream(outputPDF, FileMode.Create);
            Document pdfdoc = new Document();
            PdfWriter.GetInstance(pdfdoc, fs);
            pdfdoc.Open();
            int size = imagePaths.Length;
            foreach (string imagePath in imagePaths)
            {
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);
                img.Alignment = Element.ALIGN_CENTER;
                img.SetAbsolutePosition(0, 0);
                img.ScaleToFit((PageSize.A4.Width - pdfdoc.RightMargin - pdfdoc.LeftMargin), (PageSize.A4.Height - pdfdoc.BottomMargin - pdfdoc.TopMargin));
                pdfdoc.Add(img);
                pdfdoc.NewPage();

            }
            pdfdoc.Close();
            return pdfdoc;
        }

        public ActionResult DownloadDPKDOK(SurveyIdReq sir)
        {
            DBUtils db = new DBUtils(_survDB);
            DataTable dt = new DataTable();

            string query = "select * from VW_RESULT_UPLOAD where IDRESULTCLIENT=@id and KODE=@kode";           
            Dictionary<String, object> lsp = new Dictionary<string, object>();

            lsp.Add("@id", sir.id);
            lsp.Add("@kode", "DPKDOK");

            dt = db.GetDataTable(query, false, lsp);

            int row = -1;
            List<string> list = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dt.Rows[row]["PATH"].ToString());
                row++;
            }

            String[] str = list.ToArray();
            String fileDPKDOK = sir.id + "_DPKDOK.pdf";

            AddImageToPDF(str, fileDPKDOK);

            int code = 200;
            Response.StatusCode = code;
            return Json(new
            {
                status = code,
                message = "OK",
                url = Url.Content(fileDPKDOK)
            });
        }

        // GET: ResultController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(Guid id)
        {
            SurveyresultClient datapribadi = _survDB.SurveyresultClients.Find(id);
            List<VwResultQuisioner> kuesioner = _survDB.VwResultQuisioners.Where(a => a.Idresultclient == id).ToList();
            List<VwResultUpload> dokumen = _survDB.VwResultUploads.Where(a => a.Idresultclient == id).OrderBy(a => a.Kode).ToList();

            ViewBag.datapribadi = datapribadi;
            ViewBag.kuesioner = kuesioner;
            ViewBag.dokumen = dokumen;
            return View();
        }

        public ActionResult GetClientResult(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var listClient = new Responses.HttpResponse();

            try
            {
                listClient = SurveyRepository.GetSurveyResultClient(HttpContext.Session.GetString("BranchCode"), page, limit, keyword);

                if (listClient.totalData > 0)
                {
                    listClient.statuscode = statusCode;
                    listClient.message = "OK";
                }
                else
                {
                    statusCode = 404;
                    listClient.statuscode = statusCode;
                    listClient.message = "Not found!";
                }
            }
            catch (Exception e)
            {
                statusCode = 500;
                listClient.statuscode = statusCode;
                listClient.message = (e.Message + " " + e.StackTrace);
            }

            HttpContext.Response.StatusCode = listClient.statuscode;
            return Json(listClient);
        }
    }
}
