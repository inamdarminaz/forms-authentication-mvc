using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RepositoryPattern.Auth;

namespace RepositoryPattern.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=AppContext") { }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
    }
}