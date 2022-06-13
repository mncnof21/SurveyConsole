using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class MasterPointCheckIdnumber
    {
        public Guid Id { get; set; }
        public string PointCheckIdnumberDesc { get; set; }
        public int? IsActive { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
    }
}
