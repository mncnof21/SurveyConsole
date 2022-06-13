using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class MasterDocChecklist
    {
        public MasterDocChecklist()
        {
            MasterKelengkapans = new HashSet<MasterKelengkapan>();
        }

        public Guid Id { get; set; }
        public string Kode { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }

        public virtual ICollection<MasterKelengkapan> MasterKelengkapans { get; set; }
    }
}
