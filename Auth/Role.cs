using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepositoryPattern.Auth
{
    public class Role
    {
        public Role()
        {
            this.UserRolesMappings = new HashSet<UserRoleMapping>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRoleMapping> UserRolesMappings { get; set; }
    }
}