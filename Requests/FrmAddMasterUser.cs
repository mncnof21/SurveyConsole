using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmAddMasterUser
    {
        public string Nik { get; set; }
        public string Nama { get; set; }
        public string Password { get; set; }
        public string CCode { get; set; }
        public string GroupCode { get; set; }

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

            #region ValidateNama
            if (String.IsNullOrEmpty(Nama))
            {
                ValidationError error = new ValidationError("Nama", "Nama harus diisi");
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

            #region ValidateCCode
            if (String.IsNullOrEmpty(CCode))
            {
                ValidationError error = new ValidationError("CCode", "CCode harus diisi");
                result.Add(error);
            }
            #endregion

            #region ValidateGroupCode
            if (String.IsNullOrEmpty(GroupCode))
            {
                ValidationError error = new ValidationError("GroupCode", "GroupCode harus diisi");
                result.Add(error);
            }
            #endregion            

            return result;
        }
    }
}
