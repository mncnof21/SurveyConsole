using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.FACEDB
{
    public partial class MstUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public int? IsActive { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
    }
}
