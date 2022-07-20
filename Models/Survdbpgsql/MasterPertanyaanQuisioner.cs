using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class MasterPertanyaanQuisioner
    {
        public MasterPertanyaanQuisioner()
        {
            SurveyresultQuisioners = new HashSet<SurveyresultQuisioner>();
        }

        public Guid Id { get; set; }
        public Guid Idquisioner { get; set; }
        public Guid Idpertanyaan { get; set; }
        public string Descs { get; set; }
        public int Isactive { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }

        public virtual MasterPertanyaan IdpertanyaanNavigation { get; set; }
        public virtual MasterQuisioner IdquisionerNavigation { get; set; }
        public virtual ICollection<SurveyresultQuisioner> SurveyresultQuisioners { get; set; }
    }
}
