﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.FACEDB
{
    public partial class MasterOwnership
    {
        public int? OwnerId { get; set; }
        public string OwnerType { get; set; }
        public int? OwnerStatus { get; set; }
    }
}
