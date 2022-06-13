using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.FACEDB
{
    public partial class MasterPlat
    {
        public Guid PlatId { get; set; }
        public string PlatCode { get; set; }
        public string PlatName { get; set; }
    }
}
