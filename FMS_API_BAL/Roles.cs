using System;
using System.Collections.Generic;

namespace FMS_API_BAL
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<AdminUser>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<AdminUser> Users { get; set; }
    }
}
