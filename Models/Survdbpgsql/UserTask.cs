using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class UserTask
    {
        public Guid Id { get; set; }
        public string SurveyorNik { get; set; }
        public Guid? TaskId { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public virtual User SurveyorNikNavigation { get; set; }
        public virtual Tasklist Task { get; set; }
    }
}
