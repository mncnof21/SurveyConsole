using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class DownloadDocReq
    {
        public Guid id { set; get; }
        public string doccode { set; get; }
    }
}
