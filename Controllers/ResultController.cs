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
        private survdbContext _surveyDB;
        private IWebHostEnvironment _hostingEnvironment;
        private Auth _auth;

        public ResultController(ILogger<HomeController> logger, IConfiguration config, IWebHostEnvironment hostingEnvironment, survdbContext survDB)
        {
            _logger = logger;
            _config = config;
            _config.Bind(_appSettings);
            _survDB = survDB;
            _surveyDB = survDB;
            _hostingEnvironment = hostingEnvironment;
            _auth = new Auth(_surveyDB, _appSettings);
            SurveyRepository.db = _survDB;
            SurveyRepository.hostingEnv = _hostingEnvironment;
        }

        public iTextSharp.text.Document AddImageToPDF(String[] imagePaths, String outputPDF)
        {
            FileStream fs = new FileStream(outputPDF, FileMode.Create);
            Document pdfdoc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(pdfdoc, fs);
            //PdfCopy writer = new PdfCopy(pdfdoc, fs);

            //writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_7);
            //writer.CompressionLevel = PdfStream.BEST_COMPRESSION;
            //writer.SetFullCompression();

            pdfdoc.Open();
            int size = imagePaths.Length;            
            foreach (string imagePath in imagePaths)
            {
                string[] dtImagePath = imagePath.Split(",");

                string ext = Path.GetExtension(dtImagePath[0]);                

                if (ext == ".pdf")
                {
                    PdfReader reader = new PdfReader(dtImagePath[0]);
                    pdfdoc.Add(new Paragraph(String.Format(dtImagePath[1])));
                    for (int i=1; i<= reader.NumberOfPages; i++)
                    {
                        //writer.AddDocument(reader);
                        //reader.Close();
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        var img = iTextSharp.text.Image.GetInstance(page);
                        img.ScaleToFit((PageSize.A4.Width - pdfdoc.RightMargin - pdfdoc.LeftMargin), (PageSize.A4.Height - pdfdoc.BottomMargin - pdfdoc.TopMargin));

                        pdfdoc.SetPageSize(new Rectangle(img.Width, img.Height));
                        pdfdoc.Add(img);
                        pdfdoc.NewPage();
                        //writer.Add(iTextSharp.text.Image.GetInstance(page));
                    }
                    //writer.Close();
                }
                else if (ext == ".jpg")
                {
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(dtImagePath[0]);
                    img.ScaleToFit((PageSize.A4.Width - pdfdoc.RightMargin - pdfdoc.LeftMargin), (PageSize.A4.Height - pdfdoc.BottomMargin - pdfdoc.TopMargin));


                    pdfdoc.Add(new Paragraph(String.Format(dtImagePath[1])));
                    pdfdoc.Add(img);
                    pdfdoc.NewPage();
                }
                
            }            
            pdfdoc.Close();

            return pdfdoc;
        }

        public void CompressPDF(string pdfFileOld, string pdfFileNew)
        {
            PdfReader reader = new PdfReader(pdfFileOld);
            PdfStamper stamper =
                new PdfStamper(reader, new FileStream(pdfFileNew, FileMode.Create), PdfWriter.VERSION_1_5);

            stamper.Writer.CompressionLevel = 9;
            stamper.Close();
        }

        [HttpPost]
        public ActionResult DownloadDPKDOK(Guid id, string doccode, string noktp)
        {
            var query = _surveyDB.VwResultUploads.Where(w => w.Idresultclient.Equals(id) && w.Kode.Equals(doccode));

            var result = query.ToList();

            List<string> listdata = new List<string>();
            var separator = "\\";

            foreach (var data in result)
            {
                listdata.Add(_hostingEnvironment.ContentRootPath + separator + data.Path + "," + data.Desc);
            }            

            String[] str = listdata.ToArray();
            String uploadPath = _hostingEnvironment.ContentRootPath + separator + "Survey";
            String fileDPKDOK_Old = uploadPath + separator + noktp + "_"+ doccode + "_Old.pdf";
            String fileDPKDOK_New = uploadPath + separator + noktp + "_" + doccode + ".pdf";

            AddImageToPDF(str, fileDPKDOK_New);
            //CompressPDF(fileDPKDOK_Old, fileDPKDOK_New);
            //System.IO.File.Delete(fileDPKDOK_Old);

            int code = 200;
            Response.StatusCode = code;
            return Json(new
            {
                status = code,
                message = "OK",
                url = Url.Content("\\Survey" + separator + noktp + "_"+ doccode + ".pdf")
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

            var queryResultDownload = _survDB.VwResultUploads
                                        .GroupBy(c => new { 
                                            c.Idresultclient,
                                            c.NoKtp,
                                            c.Kode
                                        })
                                        .Select(dt => new VwResultUpload() {
                                            Idresultclient = dt.Key.Idresultclient,
                                            NoKtp = dt.Key.NoKtp,
                                            Kode = dt.Key.Kode
                                        })
                                        .Where(w => w.Idresultclient == id);
                

            var download = queryResultDownload.ToList();

            ViewBag.datapribadi = datapribadi;
            ViewBag.kuesioner = kuesioner;
            ViewBag.dokumen = dokumen;
            ViewBag.download = download;
            return View();
        }

        public ActionResult GetClientResult(int page, int limit)
        {
            int statusCode = 200;
            String keyword = HttpContext.Request.Query["keyword"];
            var listClient = new Responses.HttpResponse();

            try
            {
                listClient = SurveyRepository.GetSurveyResultClient(HttpContext.Session.GetString("BranchCode"), page, limit, (String.IsNullOrEmpty(keyword) ? null : keyword));

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
