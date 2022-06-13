using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class MasterZipCode
    {
        public int? SysZipid { get; set; }
        public string Kota { get; set; }
        public string Kecamatan { get; set; }
        public string Kelurahan { get; set; }
        public string Kodepos { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public string Areatagih { get; set; }
    }
}
