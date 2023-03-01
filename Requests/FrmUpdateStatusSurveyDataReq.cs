using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmUpdateStatusSurveyDataReq
    {
        public String application_id { get; set; }
        public String status { get; set; }
        public String wop { get; set; }
        public String fullname { get; set; }
        public String nik { get; set; }
        public String phone { get; set; }
        public String policeno { get; set; }
        public String address { get; set; }
        public String branch { get; set; }

        public List<ValidationError> Validate()
        {
            List<ValidationError> result = new List<ValidationError>();

            #region ValidateApplication_id
            if (String.IsNullOrEmpty(application_id))
            {
                ValidationError error = new ValidationError("application_id", "application_id Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateStatus
            if (String.IsNullOrEmpty(status))
            {
                ValidationError error = new ValidationError("status", "status Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateWop
            if (String.IsNullOrEmpty(wop))
            {
                ValidationError error = new ValidationError("wop", "wop Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateFullname
            if (String.IsNullOrEmpty(fullname))
            {
                ValidationError error = new ValidationError("fullname", "fullname Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateNik
            if (String.IsNullOrEmpty(nik))
            {
                ValidationError error = new ValidationError("nik", "nik Required!");
                result.Add(error);
            }
            #endregion

            #region ValidatePhone
            if (String.IsNullOrEmpty(phone))
            {
                ValidationError error = new ValidationError("phone", "phone Required!");
                result.Add(error);
            }
            #endregion

            #region ValidatePoliceno
            if (String.IsNullOrEmpty(policeno))
            {
                ValidationError error = new ValidationError("policeno", "policeno Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateAddress
            if (String.IsNullOrEmpty(address))
            {
                ValidationError error = new ValidationError("address", "address Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateBranch
            if (String.IsNullOrEmpty(branch))
            {
                ValidationError error = new ValidationError("branch", "branch Required!");
                result.Add(error);
            }
            #endregion

            return result;
        }
    }
}
