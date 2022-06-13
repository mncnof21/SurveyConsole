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
    }
}
