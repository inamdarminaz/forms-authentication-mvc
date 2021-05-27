namespace RepositoryPattern.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepositoryPattern.Models.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepositoryPattern.Models.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(r => r.RoleId,
                new Auth.Role() { RoleId=1,RoleName="Student"},
                new Auth.Role() { RoleId = 2, RoleName = "Agent" },
                new Auth.Role() { RoleId = 3, RoleName = "Admin" });

            context.Users.AddOrUpdate(u => u.Id,
                new Auth.User() { Id=1,Email="admin@admin.com",Password="admin"},
                new Auth.User() { Id = 2, Email = "agent@agent.com", Password = "agent" },
                new Auth.User() { Id = 3, Email = "student@student.com", Password = "student" }
                );

            context.UserRoleMappings.AddOrUpdate(u => u.Id,
                new Auth.UserRoleMapping() { Id = 1, RoleId = 1, UserId = 1 },
                new Auth.UserRoleMapping() { Id = 2, RoleId = 2, UserId = 2 },
                new Auth.UserRoleMapping() { Id = 3, RoleId = 3, UserId = 3 }
                );
        }
    }
}
