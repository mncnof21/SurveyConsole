using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.FACEDB
{
    public partial class MasterLocation
    {
        public int LocationId { get; set; }
        public string KodeCabang { get; set; }
        public string NamaCabang { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string NoKantor { get; set; }
        public string NoFax { get; set; }
        public string UrlLink { get; set; }
    }
}
