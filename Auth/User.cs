using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepositoryPattern.Auth
{
    public class User
    {
        public User()
        {
            this.UserRolesMappings = new HashSet<UserRoleMapping>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter an email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        public virtual ICollection<UserRoleMapping> UserRolesMappings { get; set; }
    }
}