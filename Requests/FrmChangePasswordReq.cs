using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmChangePasswordReq
    {
        public String password { get; set; }
        public String confirmpassword { get; set; }

        public List<ValidationError> Validate()
        {
            List<ValidationError> errors = new List<ValidationError>();

            #region Password
            if (String.IsNullOrEmpty(password))
            {
                errors.Add(new ValidationError("password", "New Password harus diisi!"));
            }
            #endregion

            #region Confirmpassword
            if (String.IsNullOrEmpty(confirmpassword))
            {
                errors.Add(new ValidationError("confirmpassword", "New Confirm Password harus diisi!"));
            }
            #endregion            

            return errors;
        }
    }
}
