using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class UserRole
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string CCode { get; set; }
        public string GroupCode { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }

        public virtual MasterBranch CCodeNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
