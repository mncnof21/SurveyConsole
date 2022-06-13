using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class User
    {
        public User()
        {
            UserAuths = new HashSet<UserAuth>();
            UserRoles = new HashSet<UserRole>();
            UserTasks = new HashSet<UserTask>();
        }

        public Guid Id { get; set; }
        public string Nik { get; set; }
        public string Nama { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }

        public virtual ICollection<UserAuth> UserAuths { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
