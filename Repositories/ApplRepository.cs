using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyConsole.Requests;
using SurveyConsole.Models.Survdbpgsql;
using Microsoft.EntityFrameworkCore;
using SurveyConsole.Responses;

namespace SurveyConsole.Repositories
{
    public class ApplRepository
    {

        private survdbContext _survDB = new survdbContext();

        public ApplRepository(survdbContext survDB)
        {
            _survDB = survDB;
        }

        public int CountAllAppl()
        {
            return _survDB.Tasklists.Count();
        }

        public Responses.HttpResponse GetApplPaginate(string cCode, int page = 1, int limit = 10, string keyowrd = null)
        {
            var data = _survDB.Tasklists.AsQueryable();
            if(cCode == "000")
            {
                data = _survDB.Tasklists.AsQueryable();
            }
            else
            {
                data = _survDB.Tasklists.AsQueryable().Where(a => a.Ccode == cCode);
            }

            int offset = (page * limit) - limit;
            int totalData = data.Count();

            // Filter
            if (!String.IsNullOrEmpty(keyowrd))
            {
                data = data.Where(a => a.Nama.Contains(keyowrd) || a.Alamat.Contains(keyowrd) || a.Nopol.Contains(keyowrd) || a.Notelp.Contains(keyowrd) || a.Nik.Contains(keyowrd)).AsQueryable();
                totalData = data.Count();
            }

            // count total page
            int totalPage = (Int32)(Math.Ceiling((decimal)totalData / (decimal)limit) > 0 ? Math.Ceiling((decimal)totalData / (decimal)limit) : 1);

            // Sort
            data = data.OrderByDescending(a => a.Credate).ThenByDescending(a => a.Moddate).AsQueryable();

            // Pagination
            var listData = data.Skip(offset).Take(limit).ToList();

            var result = new Responses.HttpResponse();
            result.statuscode = (listData != null && listData.Count() > 0 ? 200 : 404);
            result.message = (result.statuscode == 200 ? "OK" : "Not found!");
            result.currPage = (listData != null && listData.Count() > 0 ? page : 1);
            result.totalPage = totalPage;
            result.totalData = totalData;
            result.data = listData;

            return result;
        }        

        public Boolean CreateAppl(string cCode, string user, FrmAddAppl fac)
        {            
            Tasklist tl = new Tasklist();            

            tl.Id = Guid.NewGuid();
            tl.Nama = fac.CustName;
            tl.Nik = fac.CustNik;
            tl.Nopol = fac.UnitId;
            tl.Notelp = fac.Phone;
            tl.Alamat = fac.Address;
            tl.IsPush = 0;
            tl.Creby = user;
            tl.Ccode = cCode;

            _survDB.Tasklists.Add(tl);
            Boolean result_tl = _survDB.SaveChanges() > 0;

            _survDB.Dispose();
            return result_tl;
        }

        public Boolean CreateApplSurvey(FrmAddApplSurvey facs)
        {
            UserTask ut = new UserTask();

            ut.Id = Guid.NewGuid();
            ut.TaskId = Guid.Parse(facs.TaskId);
            ut.SurveyorNik = facs.SurveyorNik;
            ut.Latitude = facs.Latitude;
            ut.Longitude = facs.Longitude;

            _survDB.UserTasks.Add(ut);            
            Boolean result = _survDB.SaveChanges() > 0;

            var upd = _survDB.Tasklists.SingleOrDefault(a => a.Id.Equals(Guid.Parse(facs.TaskId)));
            if(upd != null)
            {
                upd.IsPush = 1;
                _survDB.SaveChanges();
            }

            _survDB.Dispose();
            return result;
        }        

        public Boolean DeleteAppl(Guid id)
        {
            var tu = _survDB.Tasklists.Find(id);
            _survDB.Tasklists.Remove(tu);

            Boolean result = _survDB.SaveChanges() > 0;
            
            _survDB.Dispose();
            return result;
        }

        ~ApplRepository()
        {
            _survDB.Dispose();
        }
    }
}
