using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmAddApplSurvey
    {
        public string TaskId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SurveyorNik { get; set; }

        public List<ValidationError> Validate()
        {
            List<ValidationError> result = new List<ValidationError>();

            #region ValidateTaskId
            if (String.IsNullOrEmpty(TaskId))
            {
                ValidationError error = new ValidationError("TaskId", "Task ID harus diisi!");
                result.Add(error);
            }
            #endregion

            #region ValidateLatitude
            if (String.IsNullOrEmpty(Latitude))
            {
                ValidationError error = new ValidationError("Latitude", "Latitude harus diisi!");
                result.Add(error);
            }
            #endregion

            #region ValidateLongitude
            if (String.IsNullOrEmpty(Longitude))
            {
                ValidationError error = new ValidationError("Longitude", "Longitude harus diisi!");
                result.Add(error);
            }
            #endregion

            #region ValidateSurveyorNik
            if (String.IsNullOrEmpty(SurveyorNik))
            {
                ValidationError error = new ValidationError("SurveyorNik", "Surveyor Nik harus diisi!");
                result.Add(error);
            }
            #endregion

            return result;
        }
    }
}
