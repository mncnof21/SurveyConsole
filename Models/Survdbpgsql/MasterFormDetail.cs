using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class MasterFormDetail
    {
        public MasterFormDetail()
        {
            SurveyresultUploads = new HashSet<SurveyresultUpload>();
        }

        public Guid Id { get; set; }
        public Guid Idform { get; set; }
        public Guid Idkelengkapan { get; set; }
        public int Count { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }

        public virtual MasterForm IdformNavigation { get; set; }
        public virtual MasterKelengkapan IdkelengkapanNavigation { get; set; }
        public virtual ICollection<SurveyresultUpload> SurveyresultUploads { get; set; }
    }
}
