using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmSendNotification
    {
        public String destinationToken { get; set; }
        public String title { get; set; }
        public String message { get; set; }
    }
}
