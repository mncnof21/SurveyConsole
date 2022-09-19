using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class ApprovedDataReq
    {
        public long approved_amount { get; set; }
        public long approved_fee { get; set; }
        public long approved_tenor { get; set; }
        public long approved_installment { get; set; }
        public long approved_disbursement { get; set; }

        public List<ValidationError> Validate()
        {
            List<ValidationError> result = new List<ValidationError>();

            #region ValidateApproved_amount
            if (String.IsNullOrEmpty(approved_amount.ToString()))
            {
                ValidationError error = new ValidationError("approved_amount", "approved_amount Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateApproved_fee
            if (String.IsNullOrEmpty(approved_fee.ToString()))
            {
                ValidationError error = new ValidationError("approved_fee", "approved_fee Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateApproved_tenor
            if (String.IsNullOrEmpty(approved_tenor.ToString()))
            {
                ValidationError error = new ValidationError("approved_tenor", "approved_tenor Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateApproved_installment
            if (String.IsNullOrEmpty(approved_installment.ToString()))
            {
                ValidationError error = new ValidationError("approved_installment", "approved_installment Required!");
                result.Add(error);
            }
            #endregion

            #region ValidateApproved_disbursement
            if (String.IsNullOrEmpty(approved_disbursement.ToString()))
            {
                ValidationError error = new ValidationError("approved_disbursement", "approved_disbursement Required!");
                result.Add(error);
            }
            #endregion

            return result;
        }
    }
}
