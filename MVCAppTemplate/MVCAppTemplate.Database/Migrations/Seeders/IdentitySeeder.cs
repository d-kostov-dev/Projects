namespace MVCAppTemplate.Database.Migrations.Seeders
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using MVCAppTemplate.Common.GlobalConstants;
    using MVCAppTemplate.DatabaseModels;
    
    public class IdentitySeeder
    {
        public static void Seed(ApplicationDbContext databaseContext)
        {
            if (!databaseContext.Roles.Any(r => r.Name == GlobalConstants.AdminRole))
            {
                var store = new RoleStore<IdentityRole>(databaseContext);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = GlobalConstants.AdminRole };

                manager.Create(role);
            }

            // Change this ASAP after installation
            if (!databaseContext.Users.Any(u => u.UserName == "admin@myapplication.com"))
            {
                var store = new UserStore<ApplicationUser>(databaseContext);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser
                {
                    UserName = "admin@myapplication.com",
                    Email = "admin@myapplication.com",
                    CreatedOn = DateTime.Now,
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, GlobalConstants.AdminRole);
            }

            databaseContext.SaveChanges();
        }
    }
}
