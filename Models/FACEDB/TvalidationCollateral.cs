using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.FACEDB
{
    public partial class TvalidationCollateral
    {
        public string Id { get; set; }
        public string ApplId { get; set; }
        public string CustName { get; set; }
        public string Nopol { get; set; }
        public string ResiNumber { get; set; }
        public int? RecommendationResult { get; set; }
        public string ReasonResult { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
    }
}
