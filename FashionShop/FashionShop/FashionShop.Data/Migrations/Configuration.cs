namespace FashionShop.Data.Migrations
{
    using FashionShop.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FashionShop.Data.FashionShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FashionShop.Data.FashionShopDbContext context)
        {
            CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.
           /* var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new FashionShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new FashionShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "fashion",
                Email = "fashionshop@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Fashion Shop"
            };
            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("fashionshop@gmail.com");
            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });*/
        }

        private void CreateProductCategorySample(FashionShop.Data.FashionShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="TOPS",Alias="tops",Status=true },
                 new ProductCategory() { Name="BOTTOM",Alias="bottom",Status=true },
                  new ProductCategory() { Name="ACCESSORIES",Alias="accessories",Status=true },
                   new ProductCategory() { Name="BAGS",Alias="bags",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }
    }
}
