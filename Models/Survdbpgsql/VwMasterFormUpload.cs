using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class VwMasterFormUpload
    {
        public Guid? Id { get; set; }
        public Guid? Idform { get; set; }
        public string Kode { get; set; }
        public string Kelengkapan { get; set; }
        public string Type { get; set; }
        public string Formname { get; set; }
        public int? Count { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public bool? Mandatory { get; set; }
        public int? Position { get; set; }
    }
}
