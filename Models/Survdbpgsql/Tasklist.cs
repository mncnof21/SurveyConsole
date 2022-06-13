using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class Tasklist
    {
        public Tasklist()
        {
            UserTasks = new HashSet<UserTask>();
        }

        public Guid Id { get; set; }
        public string Nama { get; set; }
        public string Nik { get; set; }
        public string Nopol { get; set; }
        public string Alamat { get; set; }
        public string Notelp { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public string ItrackApplid { get; set; }
        public string SiapApplid { get; set; }
        public long? IsPush { get; set; }
        public string Ccode { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
