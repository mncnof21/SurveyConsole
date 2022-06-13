using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class FrmSurvAddSurvey
    {
        public string BODYJSON { get; set; }
        public List<String> IDQUISIONERDETAIL { get; set; }
        public List<String> JAWABAN { get; set; }
        public List<String> IDFORMDETAIL { get; set; }
        public List<String> FILENAME { get; set; }
        public List<String> PATH { get; set; }
    }
}
