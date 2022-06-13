using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class UserAuth
    {
        public Guid Id { get; set; }
        public string Nik { get; set; }
        public string Password { get; set; }
        public string Authtoken { get; set; }
        public DateTime? AuthtokenExpire { get; set; }
        public string Firebasetoken { get; set; }
        public DateTime? Lastlogin { get; set; }
        public int? Attempt { get; set; }
        public DateTime? Blockuntil { get; set; }
        public string Forgottoken { get; set; }
        public DateTime? ForgottokenExpire { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public string Osextid { get; set; }

        public virtual User NikNavigation { get; set; }
    }
}
