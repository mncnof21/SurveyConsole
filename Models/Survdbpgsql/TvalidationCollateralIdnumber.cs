using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class TvalidationCollateralIdnumber
    {
        public Guid Id { get; set; }
        public Guid? IdvalidationCollateral { get; set; }
        public string IdcheckIdnumber { get; set; }
        public string CheckValue { get; set; }
        public int? IsValid { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
    }
}
