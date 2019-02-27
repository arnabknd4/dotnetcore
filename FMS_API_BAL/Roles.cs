using System;
using System.Collections.Generic;

namespace FMS_API_BAL
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
