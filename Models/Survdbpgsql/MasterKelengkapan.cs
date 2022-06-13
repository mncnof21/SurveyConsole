using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class MasterKelengkapan
    {
        public MasterKelengkapan()
        {
            MasterFormDetails = new HashSet<MasterFormDetail>();
        }

        public Guid Id { get; set; }
        public Guid IdDocChecklist { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public string Formname { get; set; }
        public bool? Mandatory { get; set; }
        public int? Position { get; set; }
        public int? Isactive { get; set; }

        public virtual MasterDocChecklist IdDocChecklistNavigation { get; set; }
        public virtual ICollection<MasterFormDetail> MasterFormDetails { get; set; }
    }
}
