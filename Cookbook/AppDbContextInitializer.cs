using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Cookbook.Models;
using Cookbook.Security;

namespace Cookbook
{
    public class AppDbContextInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            base.Seed(context);

            AddUsers(context);

            AddProducts(context);
        }

        private void AddUsers(AppDbContext context)
        {
            var user = new User();
            user.Role = UserRole.Admin;
            user.Login = "Ninja";
            var password = "pwd";

            var hashManager = new PBKDF2HashManager();
            var pair = hashManager.GetKeyAndSalt(password);

            user.PasswordKey = pair.Key;
            user.PasswordSalt = pair.Salt;

            context.Users.Add(user);

            user = new User();
            user.Role = UserRole.User;
            user.Login = "User1";
            password = "pwd1";

            pair = hashManager.GetKeyAndSalt(password);

            user.PasswordKey = pair.Key;
            user.PasswordSalt = pair.Salt;
            
            context.Users.Add(user);

            context.SaveChanges();

            AddUser(context, "polishUser", "ąęć");
        }

        private void AddUser(AppDbContext context, string login, string password,
            UserRole role = UserRole.User)
        {
            var hashManager = new PBKDF2HashManager();
            var pair = hashManager.GetKeyAndSalt(password);

            var user = new User();
            user.Login = login;
            user.PasswordKey = pair.Key;
            user.PasswordSalt = pair.Salt;
            user.Role = role;

            context.Users.Add(user);
            context.SaveChanges();
        }

        private void AddProducts(AppDbContext context)
        {
            var product = new Product()
            {
                Name = "Pierś z kurczaka",
                Category = ProductCategory.Meat,
                KcalPer100Grams = 121,
                Origin = ItemOrigin.Basic
            };
            context.Products.Add(product);

            product = new Product()
            {
                Name = "Ryż",
                Category = ProductCategory.Vegetable,
                KcalPer100Grams = 350,
                Origin = ItemOrigin.Basic
            };
            context.Products.Add(product);

            product = new Product()
            {
                Name = "Brokuł",
                Category = ProductCategory.Vegetable,
                KcalPer100Grams = 29,
                Origin = ItemOrigin.Basic
            };
            context.Products.Add(product);

            context.SaveChanges();
        }
    }
}