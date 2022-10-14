using Microsoft.EntityFrameworkCore;
using SurveyConsole.Models.Survdbpgsql;
using SurveyConsole.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyConsole.Libs;
using Microsoft.AspNetCore.Http;
using SurveyConsole.Models;

namespace SurveyConsole.Repositories
{
    public class UserRepository
    {
        private survdbContext _survDB;
        AppsSettings _appSetting;

        public UserRepository(survdbContext survDB, AppsSettings appSetting)
        {
            _survDB = survDB;
            _appSetting = appSetting;
        }

        public VwUser findUser(FrmLogin frmlogin)
        {
            return _survDB.VwUsers.Where(a => a.Nik == frmlogin.nik).FirstOrDefault();
        }

        public VwUser findUserAuth(FrmLogin frmlogin)
        {
            var user = findUser(frmlogin);

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(frmlogin.password, user.Password))
                {
                    return user;
                }
            }

            return null;
        }

        public Responses.HttpResponse GetMasterUserPaginate(int page = 1, int limit = 10, string keyowrd = null)
        {
            var data = _survDB.Users.AsQueryable();            

            int offset = (page * limit) - limit;
            int totalData = data.Count();

            // Filter
            if (!String.IsNullOrEmpty(keyowrd))
            {
                data = data.Where(a => a.Nik.Contains(keyowrd) || a.Nama.Contains(keyowrd)).AsQueryable();
                totalData = data.Count();
            }

            // count total page
            int totalPage = (Int32)(Math.Ceiling((decimal)totalData / (decimal)limit) > 0 ? Math.Ceiling((decimal)totalData / (decimal)limit) : 1);

            // Sort
            data = data.OrderByDescending(a => a.Credate).AsQueryable();

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

        public Responses.HttpResponse GetMasterUserBranch(int page = 1, int limit = 10, string keyowrd = null)
        {
            var query = from usr in _survDB.Users
                     join usrrole in _survDB.UserRoles
                     on usr.Nik equals usrrole.UserId
                     join mstbranch in _survDB.MasterBranches
                     on usrrole.CCode equals mstbranch.CCode
                     where usr.Nik == keyowrd
                        select new
                     {
                         Id = usrrole.Id,
                         UserId = usr.Nik,
                         Nama = usr.Nama,
                         Branch = mstbranch.CName,
                         Credate = usrrole.Credate
                     };

            var data = query.AsQueryable();

            int offset = (page * limit) - limit;
            int totalData = data.Count();

            // Filter
            if (!String.IsNullOrEmpty(keyowrd))
            {
                data = data.Where(a => a.UserId.Contains(keyowrd) || a.Nama.Contains(keyowrd)).AsQueryable();
                totalData = data.Count();
            }

            // count total page
            int totalPage = (Int32)(Math.Ceiling((decimal)totalData / (decimal)limit) > 0 ? Math.Ceiling((decimal)totalData / (decimal)limit) : 1);

            // Sort
            data = data.OrderByDescending(a => a.Credate).AsQueryable();

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

        public Boolean DeleteBranchUser(Guid id)
        {
            var tu = _survDB.UserRoles.Find(id);
            _survDB.UserRoles.Remove(tu);

            Boolean result = _survDB.SaveChanges() > 0;

            _survDB.Dispose();
            return result;
        }

        public Boolean DeleteUser(Guid id)
        {
            var dtuser = _survDB.Users.Find(id);

            string nik = dtuser.Nik;            

            var deluserroles = _survDB.UserRoles.Where(a => a.UserId == nik).ToList();

            foreach (var item in deluserroles)
            {
                var deluserrole = _survDB.UserRoles.Where(a => a.Id == item.Id).FirstOrDefault();
                _survDB.UserRoles.Remove(deluserrole);
            }                

            var deluserauth = _survDB.UserAuths.Where(a => a.Nik == nik).FirstOrDefault();
            _survDB.UserAuths.Remove(deluserauth);

            var deluser = _survDB.Users.Where(a => a.Nik == nik).FirstOrDefault();
            _survDB.Users.Remove(deluser);

            Boolean result = _survDB.SaveChanges() > 0;

            _survDB.Dispose();
            return result;
        }
    }
}
