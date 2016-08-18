using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShopTu.Model;

namespace ShopTu.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopTu.Data.TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopTu.Data.TeduShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));
            var user = new ApplicationUser()
            {
                UserName = "tuhoang",
                Email = "hoangtu92tn@gmail.com",
                EmailConfirmed = true,
                BirtDay = DateTime.Now,
                FullName = "Hoang Ngoc Tu"
            };
            manager.Create(user, "123123123");
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole {Name = "Admin"});
                roleManager.Create(new IdentityRole { Name = "User" });
            }
            var adminUser = manager.FindByEmail("hoangtu92tn@gmail.com");
            manager.AddToRoles(adminUser.Id, new string[] {"Admin", "User"});

        }
    }
}
