using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyConsole.Models.Survdbpgsql;
using SurveyConsole.Requests;
using SurveyConsole.Libs;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using SurveyConsole.Responses;

namespace SurveyConsole.Repositories
{
    public class SurveyRepository
    {
        public static survdbContext db { get; set; }
        public static IWebHostEnvironment hostingEnv { get; set; }

        public static Boolean CreateSurvey(String user, FrmSurvAddSurvey survey, List<VwMasterFormUpload> formList, Dictionary<String, List<IFormFile>> formFiles)
        {
            Guid newId = Guid.NewGuid();
            Guid result;
            Guid idquestion;

            String separator = "\\";
            String uploadPath = hostingEnv.ContentRootPath + separator + "Survey";
            String uploadPathDB = separator + "Survey";
            String folderDoc = "";
            String folderDocDB = "";

            FrmSurvAddClient clientData = JsonConvert.DeserializeObject<FrmSurvAddClient>(survey.BODYJSON);
            Guid.TryParse(clientData.TASKID, out result);

            SurveyresultClient client = new SurveyresultClient();
            Guid.TryParse(clientData.IDQUESTION, out idquestion);
            client.Id = newId;
            client.GelarDepan = clientData.GELAR_DEPAN;
            client.Nama = clientData.NAMA;
            client.GelarBelakang = clientData.GELAR_BELAKANG;
            client.NamaKtp = clientData.NAMA_KTP;
            client.NoKtp = clientData.NO_KTP;
            client.KtpExpireFrom = (Helper.ConvertDateFromString(clientData.KTP_EXPIRE_FROM, "-"));
            client.KtpExpireTo = (Helper.ConvertDateFromString(clientData.KTP_EXPIRE_TO, "-"));
            client.Ao = clientData.AO;
            client.Tgllahir = (Helper.ConvertDateFromString(clientData.TGLLAHIR, "-"));
            client.Tempatlahir = clientData.TEMPATLAHIR;
            client.Namaibu = clientData.NAMAIBU;
            client.Alamat = clientData.ALAMAT;
            client.Rt = clientData.RT;
            client.Rw = clientData.RW;
            client.Kodepos = clientData.KODEPOS;
            client.Kelurahan = clientData.KELURAHAN;
            client.Kecamatan = clientData.KECAMATAN;
            client.Hpno = clientData.HPNO;
            client.Telpno = clientData.TELPNO;
            client.Faxno = clientData.FAXNO;
            client.Nopol = clientData.NOPOL;
            client.Credate = DateTime.Now;
            client.Creby = user;
            client.Credate = DateTime.Now;
            client.Creby = user;
            client.Lat = clientData.LAT;
            client.Lng = clientData.LNG;
            client.Taskid = (result == Guid.Empty ? null : result);

            db.SurveyresultClients.Add(client);

            if (formFiles != null && formFiles.Count > 0)
            {
                if (!System.IO.Directory.Exists(uploadPath))
                {
                    System.IO.Directory.CreateDirectory(uploadPath);
                }

                uploadPath = uploadPath + separator + client.NoKtp;
                uploadPathDB = uploadPathDB + separator + client.NoKtp;

                if (!System.IO.Directory.Exists(uploadPath))
                {
                    System.IO.Directory.CreateDirectory(uploadPath);
                }

                foreach (var item in formFiles)
                {
                    var strkey = item.Key;
                    var strvalue = item.Value;
                    var index = formFiles.ToList().IndexOf(item);

                    var query = from masterFormDetail in db.MasterFormDetails
                                join masterKelengkapan in db.MasterKelengkapans
                                on masterFormDetail.Idkelengkapan equals masterKelengkapan.Id
                                where masterKelengkapan.Formname == strkey
                                select new 
                                {
                                    IdFormDetail = masterFormDetail.Id
                                };
                    var resultFormDetail = query.ToList();

                    var strId = "";
                    foreach (var itemFormDetail in resultFormDetail)
                    {
                        strId = itemFormDetail.IdFormDetail.ToString();
                    }

                    foreach (var file in item.Value)
                    {
                        SurveyresultUpload upload = new SurveyresultUpload();
                        //Guid idformDetail;                        

                        upload.Idformdetail = Guid.Parse(strId);

                        //if(Guid.TryParse(survey.IDFORMDETAIL[index], out idformDetail))
                        //{
                        //    upload.Idformdetail = idformDetail;
                        //}

                        String filename = file.FileName;
                        String[] arrSplit = filename.Split('.');
                        String ext = (arrSplit.Count() > 1 ? arrSplit[arrSplit.Count() - 1] : "");

                        String saveFileName = client.NoKtp + "_" + client.Nopol.Replace(" ", "") + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss_fff") + "_" + item.Key.Replace('&', '-') + (String.IsNullOrEmpty(ext) ? "" : "." + ext);                                               

                        folderDoc = uploadPath + separator + strkey;
                        folderDocDB = uploadPathDB + separator + strkey;

                        if (!System.IO.Directory.Exists(folderDoc))
                        {
                            System.IO.Directory.CreateDirectory(folderDoc);
                        }

                        using (Stream fileStream = new FileStream(folderDoc + separator + saveFileName, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }


                        //uploadPath += separator + client.Id.ToString("D"); //newId.ToString("D");
                        //uploadPathDB += separator + client.Id.ToString("D");

                        //if (!System.IO.Directory.Exists(uploadPath))
                        //{
                        //    System.IO.Directory.CreateDirectory(uploadPath);
                        //}

                        //using (Stream fileStream = new FileStream(uploadPath + separator + saveFileName, FileMode.Create))
                        //{
                        //    file.CopyTo(fileStream);
                        //}

                        
                        String filePath = folderDocDB + separator + saveFileName;

                        upload.Filename = saveFileName;
                        upload.Path = filePath;
                        upload.Credate = DateTime.Now;
                        upload.Creby = user;
                        upload.Idresultclient = newId;

                        db.SurveyresultUploads.Add(upload);
                    }
                }
            }

            List<Guid?> listQuestion = db.VwQuisioners.Where(a => a.Idquisioner == idquestion).OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).Select(a => a.Id).ToList();

            if (survey.IDQUISIONERDETAIL != null && survey.IDQUISIONERDETAIL.Count() > 0)
            {
                int i = 0;
                foreach (var item in survey.IDQUISIONERDETAIL)
                {
                    Guid idquesionerdetail;

                    if (Guid.TryParse(item, out idquesionerdetail) && idquestion != Guid.Empty)
                    {
                        SurveyresultQuisioner itemSurvey = new SurveyresultQuisioner();
                        itemSurvey.Id = Guid.NewGuid();
                        itemSurvey.Idquisioner = idquestion;
                        itemSurvey.Idquisionerdetail = idquesionerdetail;
                        itemSurvey.Idsurveyclient = newId;
                        itemSurvey.Jawaban = survey.JAWABAN.ElementAtOrDefault(i);
                        itemSurvey.Credate = DateTime.Now;
                        itemSurvey.Creby = user;
                        itemSurvey.Moddate = DateTime.Now;
                        itemSurvey.Modby = user;

                        db.SurveyresultQuisioners.Add(itemSurvey);
                        i++;
                    }
                    else
                    {
                        throw new Exception("Unable to parse Guid!");
                    }
                }
            }

            return db.SaveChanges() > 0;
        }

        public static Responses.HttpResponse GetSurveyResultClient(string ccode, int page = 1, int limit = 10, string keyword = null)
        {

            //var queryresult = db.SurveyresultClients.Join(db.Tasklists, src => src.Taskid, tl => tl.Id, (src, tl) => new { src, tl }).Join(db.UserTasks, combi => combi.tl.Id, ut => ut.TaskId)

            var query = from sc in db.Set<SurveyresultClient>()
                        from tl in db.Set<Tasklist>().Where(tl => sc.Taskid == tl.Id)
                        from ut in db.Set<UserTask>().Where(ut => tl.Id == ut.TaskId)
                        select new SurveyresultClient()
                        {
                            Id = sc.Id,
                            GelarDepan = sc.GelarDepan,
                            Nama = sc.Nama,
                            GelarBelakang = sc.GelarBelakang,
                            NamaKtp = sc.NamaKtp,
                            NoKtp = sc.NoKtp,
                            KtpExpireFrom = sc.KtpExpireFrom,
                            KtpExpireTo = sc.KtpExpireTo,
                            Ao = sc.Ao,
                            Tgllahir = sc.Tgllahir,
                            Tempatlahir = sc.Tempatlahir,
                            Namaibu = sc.Namaibu,
                            Alamat = sc.Alamat,
                            Rt = sc.Rt,
                            Rw = sc.Rw,
                            Kodepos = sc.Kodepos,
                            Kelurahan = sc.Kelurahan,
                            Kecamatan = sc.Kecamatan,
                            Hpno = sc.Hpno,
                            Telpno = sc.Telpno,
                            Faxno = sc.Faxno,
                            Nopol = sc.Nopol,
                            Credate = sc.Credate,
                            Creby = sc.Creby,
                            Moddate = sc.Moddate,
                            Modby = sc.Modby,
                            Lat = sc.Lat,
                            Lng = sc.Lng,
                            Taskid = sc.Taskid
                        };
            if (ccode == "000")
            {
                query = from sc in db.Set<SurveyresultClient>()
                        from tl in db.Set<Tasklist>().Where(tl => sc.Taskid == tl.Id)
                        from ut in db.Set<UserTask>().Where(ut => tl.Id == ut.TaskId)
                        select new SurveyresultClient()
                        {
                            Id = sc.Id,
                            GelarDepan = sc.GelarDepan,
                            Nama = sc.Nama,
                            GelarBelakang = sc.GelarBelakang,
                            NamaKtp = sc.NamaKtp,
                            NoKtp = sc.NoKtp,
                            KtpExpireFrom = sc.KtpExpireFrom,
                            KtpExpireTo = sc.KtpExpireTo,
                            Ao = sc.Ao,
                            Tgllahir = sc.Tgllahir,
                            Tempatlahir = sc.Tempatlahir,
                            Namaibu = sc.Namaibu,
                            Alamat = sc.Alamat,
                            Rt = sc.Rt,
                            Rw = sc.Rw,
                            Kodepos = sc.Kodepos,
                            Kelurahan = sc.Kelurahan,
                            Kecamatan = sc.Kecamatan,
                            Hpno = sc.Hpno,
                            Telpno = sc.Telpno,
                            Faxno = sc.Faxno,
                            Nopol = sc.Nopol,
                            Credate = sc.Credate,
                            Creby = sc.Creby,
                            Moddate = sc.Moddate,
                            Modby = sc.Modby,
                            Lat = sc.Lat,
                            Lng = sc.Lng,
                            Taskid = sc.Taskid
                        };
            }
            else
            {
                query = from sc in db.Set<SurveyresultClient>()
                        from tl in db.Set<Tasklist>().Where(tl => sc.Taskid == tl.Id)
                        from ut in db.Set<UserTask>().Where(ut => tl.Id == ut.TaskId)
                        where (tl.Ccode == ccode)
                        select new SurveyresultClient()
                        {
                            Id = sc.Id,
                            GelarDepan = sc.GelarDepan,
                            Nama = sc.Nama,
                            GelarBelakang = sc.GelarBelakang,
                            NamaKtp = sc.NamaKtp,
                            NoKtp = sc.NoKtp,
                            KtpExpireFrom = sc.KtpExpireFrom,
                            KtpExpireTo = sc.KtpExpireTo,
                            Ao = sc.Ao,
                            Tgllahir = sc.Tgllahir,
                            Tempatlahir = sc.Tempatlahir,
                            Namaibu = sc.Namaibu,
                            Alamat = sc.Alamat,
                            Rt = sc.Rt,
                            Rw = sc.Rw,
                            Kodepos = sc.Kodepos,
                            Kelurahan = sc.Kelurahan,
                            Kecamatan = sc.Kecamatan,
                            Hpno = sc.Hpno,
                            Telpno = sc.Telpno,
                            Faxno = sc.Faxno,
                            Nopol = sc.Nopol,
                            Credate = sc.Credate,
                            Creby = sc.Creby,
                            Moddate = sc.Moddate,
                            Modby = sc.Modby,
                            Lat = sc.Lat,
                            Lng = sc.Lng,
                            Taskid = sc.Taskid
                        };
            }

            
            var data = query.AsQueryable();

            int totalData = data.Count();
            int offset = (page * limit) - limit;

            // Filter
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(a => a.GelarDepan.Contains(keyword) ||
                                        a.Nama.Contains(keyword) ||
                                        a.GelarBelakang.Contains(keyword) ||
                                        a.NamaKtp.Contains(keyword) ||
                                        a.NoKtp.Contains(keyword) ||
                                        a.Ao.Contains(keyword) ||
                                        a.Tempatlahir.Contains(keyword) ||
                                        a.Namaibu.Contains(keyword) ||
                                        a.Alamat.Contains(keyword) ||
                                        a.Rt.Contains(keyword) ||
                                        a.Rw.Contains(keyword) ||
                                        a.Kodepos.Contains(keyword) ||
                                        a.Kelurahan.Contains(keyword) ||
                                        a.Kecamatan.Contains(keyword) ||
                                        a.Hpno.Contains(keyword) ||
                                        a.Telpno.Contains(keyword) ||
                                        a.Faxno.Contains(keyword) ||
                                        a.Nopol.Contains(keyword) ||
                                        a.Lat.Contains(keyword) ||
                                        a.Lng.Contains(keyword)).AsQueryable();

                totalData = data.Count();
            }

            // Count total page
            int totalPage = (Int32)(Math.Ceiling((decimal)totalData / (decimal)limit) > 0 ? Math.Ceiling((decimal)totalData / (decimal)limit) : 1);

            // Order
            data = data.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).AsQueryable();

            //Pagination
            var listdata = data.Skip(offset).Take(limit).ToList();

            var result = new Responses.HttpResponse();
            result.statuscode = (listdata != null && listdata.Count() > 0 ? 200 : 404);
            result.message = (result.statuscode == 200 ? "OK" : "Not found!");
            result.currPage = (listdata != null && listdata.Count() > 0 ? page : 1);
            result.totalData = totalData;
            result.totalPage = totalPage;
            result.data = listdata;

            return result;
        }

        public static List<VwResultUpload> GetSurveyResultUpload(Guid idresultclient)
        {
            var data = db.VwResultUploads.AsQueryable();

            return data.ToList();
        }

        public static List<VwResultQuisioner> GetSurveyResultQuisioner(Guid idresultclient)
        {
            var data = db.VwResultQuisioners.AsQueryable();

            return data.ToList();
        }
    }
}
