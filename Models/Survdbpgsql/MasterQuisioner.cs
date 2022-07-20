using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class MasterQuisioner
    {
        public MasterQuisioner()
        {
            MasterPertanyaanQuisioners = new HashSet<MasterPertanyaanQuisioner>();
        }

        public Guid Id { get; set; }
        public string Desc { get; set; }
        public int Isactive { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }

        public virtual ICollection<MasterPertanyaanQuisioner> MasterPertanyaanQuisioners { get; set; }
    }
}
