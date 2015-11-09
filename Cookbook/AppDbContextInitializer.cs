using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Cookbook.Models;
using Cookbook.Security;

namespace Cookbook
{
    public class AppDbContextInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            base.Seed(context);

            var admin = new User();
            admin.Role = UserRole.Admin;
            admin.Login = "Ninja";
            var password = "pwd";

            var hashManager = new PBKDF2HashManager();
            var pair = hashManager.GetKeyAndSalt(password);

            admin.PasswordKey = pair.Key;
            admin.PasswordSalt = pair.Salt;

            context.Users.Add(admin);
            context.SaveChanges();
        }
    }
}