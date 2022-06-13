using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class TvalidationCollateralPhysical
    {
        public Guid Id { get; set; }
        public Guid? IdvalidationCollateral { get; set; }
        public string IdcheckPhysical { get; set; }
        public int? IsValid { get; set; }
        public string Reason { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
    }
}
