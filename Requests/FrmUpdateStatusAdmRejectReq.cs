using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmUpdateStatusAdmRejectReq
    {
        public String application_id { get; set; }
        public String status { get; set; }
        public String reason { get; set; }

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

            #region ValidateReason
            if (String.IsNullOrEmpty(reason))
            {
                ValidationError error = new ValidationError("reason", "reason Required!");
                result.Add(error);
            }
            #endregion

            return result;
        }
    }
}
