using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class SurveyresultQuisioner
    {
        public Guid Id { get; set; }
        public Guid Idquisioner { get; set; }
        public Guid Idquisionerdetail { get; set; }
        public Guid Idsurveyclient { get; set; }
        public string Jawaban { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }

        public virtual MasterPertanyaanQuisioner IdquisionerdetailNavigation { get; set; }
        public virtual SurveyresultClient IdsurveyclientNavigation { get; set; }
    }
}
