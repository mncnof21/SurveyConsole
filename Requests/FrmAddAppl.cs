using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyConsole.Libs;

namespace SurveyConsole.Requests
{
    public class FrmAddAppl
    {
        public string CustName { get; set; }
        public string CustNik { get; set; }
        public string Phone { get; set; }
        public string UnitId { get; set; }
        public string Address { get; set; }

        public List<ValidationError> Validate()
        {
            List<ValidationError> result = new List<ValidationError>();

            #region ValidateCustName
            if (String.IsNullOrEmpty(CustName))
            {
                ValidationError error = new ValidationError("CustName", "Nama harus diisi!");
                result.Add(error);
            }
            #endregion

            #region ValidateCustNik
            if (String.IsNullOrEmpty(CustNik))
            {
                ValidationError error = new ValidationError("CustNik", "NIK harus diisi!");
                result.Add(error);
            }
            #endregion

            #region ValidatePhone
            if (String.IsNullOrEmpty(Phone))
            {
                ValidationError error = new ValidationError("Phone", "Nomor telepon harus diisi!");
                result.Add(error);
            }
            #endregion

            #region ValidateNopol
            if (String.IsNullOrEmpty(Address))
            {
                ValidationError error = new ValidationError("Address", "Alamat harus diisi!");
                result.Add(error);
            }
            #endregion

            return result;
        }
    }
}
