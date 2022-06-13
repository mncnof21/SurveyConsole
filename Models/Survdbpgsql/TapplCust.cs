using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class TapplCust
    {
        public string ApplId { get; set; }
        public string ApplType { get; set; }
        public string ApplStatus { get; set; }
        public string CustName { get; set; }
        public string CustNik { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CustDesc1 { get; set; }
        public string CustDesc2 { get; set; }
        public int? JumUnit { get; set; }
        public int? YearUnit { get; set; }
        public string ProductFacility { get; set; }
        public string BranchId { get; set; }
        public string Notes { get; set; }
        public DateTime? PromiseDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
