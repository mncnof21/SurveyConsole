using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmChangePassword
    {
        public string Nik { get; set; }
        public string Password { get; set; }        

        public List<ValidationError> Validate()
        {
            List<ValidationError> result = new List<ValidationError>();

            #region ValidateNik
            if (String.IsNullOrEmpty(Nik))
            {
                ValidationError error = new ValidationError("Nik", "Nik harus diisi");
                result.Add(error);
            }
            #endregion

            #region ValidatePassword
            if (String.IsNullOrEmpty(Password))
            {
                ValidationError error = new ValidationError("Password", "Password harus diisi");
                result.Add(error);
            }
            #endregion            

            return result;
        }
    }
}
