using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class VwResultUpload
    {
        public Guid? Id { get; set; }
        public Guid? Idresultclient { get; set; }
        public string Nama { get; set; }
        public string NoKtp { get; set; }
        public string Formname { get; set; }
        public string Desc { get; set; }
        public string Kode { get; set; }
        public string Filename { get; set; }
        public string Path { get; set; }
    }
}
