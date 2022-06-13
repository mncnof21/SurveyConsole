using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class SurveyresultUpload
    {
        public Guid Id { get; set; }
        public Guid? Idresultclient { get; set; }
        public Guid Idformdetail { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }

        public virtual MasterFormDetail IdformdetailNavigation { get; set; }
        public virtual SurveyresultClient IdresultclientNavigation { get; set; }
    }
}
