using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SurveyConsole.Models;
using SurveyConsole.Models.Survdbpgsql;
using SurveyConsole.Repositories;
using SurveyConsole.Requests;

namespace SurveyConsole.Libs
{
    public class Auth
    {
        survdbContext _db;
        UserRepository _userRepo;
        AppsSettings _appSetting;

        public Auth(survdbContext db, AppsSettings appSetting)
        {
            _db = db;
            _userRepo = new UserRepository(_db, appSetting);
            _appSetting = appSetting;
        }        

        public List<String> checkLogin(FrmLogin frmlogin, HttpContext http)
        {
            VwUser vwuser = _userRepo.findUserAuth(frmlogin);
            List<String> jwt = new List<string>() { };

            if (vwuser != null)
            {
                var user = _db.UserAuths.Where(a => a.Nik == vwuser.Nik).FirstOrDefault();
                user.Firebasetoken = frmlogin.token;
                _db.SaveChanges();

                Dictionary<String, Object> claims = new Dictionary<string, object>() { };
                claims.Add("NIK", vwuser.Nik);
                claims.Add("GroupCode", vwuser.GroupCode);
                claims.Add("Attempt", vwuser.Attempt);                

                jwt = Oauth.Generate(http, claims, _appSetting);

                return jwt;
            }

            return null;
        }

        public Dictionary<String, object> checkLoginData(FrmLogin frmlogin)
        {
            VwUser vwuser = _userRepo.findUser(frmlogin);
            Dictionary<String, object> dataUser = new Dictionary<String, object>() { };

            if (vwuser != null)
            {
                dataUser.Add("Nik", vwuser.Nik);
                dataUser.Add("Nama", vwuser.Nama);
                //dataUser.Add("CCode", vwuser.CCode);
                return dataUser;
            }

            return null;
        }

        public Boolean checkAdmin(UserAuth user)
        {
            return false;
            //if(getUserFromSession().UserRoles)
        }

        public Boolean checkSuperAdmin(UserAuth user)
        {
            return false;
        }

        public Boolean checkSession(UserAuth user)
        {
            return false;
        }

        public User getUserFromSession(HttpContext http)
        {
            try
            {
                String jsonuser = http.Session.GetString("User");
                User user = JsonConvert.DeserializeObject<User>(jsonuser);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
