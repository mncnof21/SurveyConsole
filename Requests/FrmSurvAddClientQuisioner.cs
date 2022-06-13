using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmSurvAddClientQuisioner
    {
        public string ID { get; set; }
        public string IDQUISIONER { get; set; }
        public string IDQUISIONERDETAIL { get; set; }
        public string IDSURVEYCLIENT { get; set; }
        public string JAWABAN { get; set; }
        public string CREDATE { get; set; }
        public string CREBY { get; set; }
        public string MODDATE { get; set; }
        public string MODBY { get; set; }
    }
}
