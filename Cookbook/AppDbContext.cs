using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Cookbook.Models;
using Cookbook.Services.EFServices;

namespace Cookbook
{
    public class AppDbContext : DbContext, IDbContextService
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
            Database.SetInitializer<AppDbContext>(new DropCreateDatabaseIfModelChanges<AppDbContext>());
        }

        public AppDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            Database.SetInitializer<AppDbContext>(new DropCreateDatabaseIfModelChanges<AppDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().MapToStoredProcedures();
        }

        public new void Dispose()
        {
            base.Dispose();
            throw new Exception("dispose called.");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Meal> Meals { get; set; }
    }
}