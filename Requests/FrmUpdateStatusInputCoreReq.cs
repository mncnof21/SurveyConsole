using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmUpdateStatusInputCoreReq
    {
        public String application_id { get; set; }
        public String status { get; set; }
        public String contract_number { get; set; }

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

            #region ValidateContract_number
            if (String.IsNullOrEmpty(contract_number))
            {
                ValidationError error = new ValidationError("contract_number", "contract_number Required!");
                result.Add(error);
            }
            #endregion

            return result;
        }
    }
}
