using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class VwResultQuisioner
    {
        public Guid? Id { get; set; }
        public Guid? Idresultclient { get; set; }
        public string Nama { get; set; }
        public string NoKtp { get; set; }
        public string Pertanyaan { get; set; }
        public int? QuestionTypeFlag { get; set; }
        public string Jawaban { get; set; }
    }
}
