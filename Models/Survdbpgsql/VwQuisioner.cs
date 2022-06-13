using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class VwQuisioner
    {
        public Guid? Id { get; set; }
        public Guid? Idquisioner { get; set; }
        public Guid? Idpertanyaan { get; set; }
        public string Pertanyaan { get; set; }
        public int? QuestionTypeFlag { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public bool? Mandatory { get; set; }
        public int? Position { get; set; }
    }
}
