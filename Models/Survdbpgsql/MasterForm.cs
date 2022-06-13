using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class MasterForm
    {
        public MasterForm()
        {
            MasterFormDetails = new HashSet<MasterFormDetail>();
        }

        public Guid Id { get; set; }
        public string Desc { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public bool? Mandatory { get; set; }

        public virtual ICollection<MasterFormDetail> MasterFormDetails { get; set; }
    }
}
