using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.FACEDB
{
    public partial class MasterJob
    {
        public int? JobId { get; set; }
        public string JobName { get; set; }
        public int? JobStatus { get; set; }
    }
}
