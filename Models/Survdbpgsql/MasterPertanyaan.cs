using System;
using System.Collections.Generic;
using System.Collections;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class MasterPertanyaan
    {
        public MasterPertanyaan()
        {
            MasterPertanyaanQuisioners = new HashSet<MasterPertanyaanQuisioner>();
        }

        public Guid Id { get; set; }
        public string Pertanyaan { get; set; }
        public int QuestionTypeFlag { get; set; }
        public BitArray Isactive { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public bool? Mandatory { get; set; }
        public int? Position { get; set; }

        public virtual ICollection<MasterPertanyaanQuisioner> MasterPertanyaanQuisioners { get; set; }
    }
}
