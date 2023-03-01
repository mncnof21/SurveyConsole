using System;

namespace SurveyConsole.Requests
{
    public class FrmUpdateStatusSurveyMCReq
    {
        public String application_id { get; set; }
        public String status { get; set; }
        public String wop { get; set; }
    }
}
