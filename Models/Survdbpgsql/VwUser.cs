using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class VwUser
    {
        public string Nik { get; set; }
        public string Nama { get; set; }
        public string GroupCode { get; set; }
        public string CCode { get; set; }
        public string Password { get; set; }
        public string Firebasetoken { get; set; }
        public string Authtoken { get; set; }
        public DateTime? AuthtokenExpire { get; set; }
        public int? Attempt { get; set; }
        public DateTime? Blockuntil { get; set; }
        public string Forgottoken { get; set; }
        public DateTime? Lastlogin { get; set; }
    }
}
