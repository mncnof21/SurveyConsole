using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SurveyConsole.Requests
{
    public class FrmSurvAddClientDocument
    {
        public string ID { get; set; }
        public string IDRESULTCLIENT { get; set; }
        public string IDFORMDETAIL { get; set; }
        public string FORMNAME { get; set; }
        public string FILENAME { get; set; }
        public string PATH { get; set; }
        public string CREDATE { get; set; }
        public string CREBY { get; set; }
        public string MODDATE { get; set; }
        public string MODBY { get; set; }
    }
}
