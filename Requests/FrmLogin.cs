using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmLogin
    {
        public String nik { get; set; }
        public String password { get; set; }
        public String branch { get; set; }
        public String token { get; set; }

        public List<ValidationError> Validate()
        {
            List<ValidationError> errors = new List<ValidationError>();

            #region NIK
            if (String.IsNullOrEmpty(nik))
            {
                errors.Add(new ValidationError("nik", "NIK harus diisi!"));
            }
            #endregion

            #region Password
            if (String.IsNullOrEmpty(password))
            {
                errors.Add(new ValidationError("password", "Password harus diisi!"));
            }
            #endregion

            #region Branch
            if (String.IsNullOrEmpty(branch))
            {
                errors.Add(new ValidationError("branch", "Branch harus diisi!"));
            }
            #endregion

            return errors;
        }
    }
}
