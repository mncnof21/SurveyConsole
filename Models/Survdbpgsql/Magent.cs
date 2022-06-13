using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class Magent
    {
        public Guid Id { get; set; }
        public string AgentId { get; set; }
        public string AgentName { get; set; }
        public string Email { get; set; }
        public string Nik { get; set; }
        public string NikName { get; set; }
        public string HpNo { get; set; }
        public string NikAddress { get; set; }
        public int? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string FilePhoto { get; set; }
    }
}
