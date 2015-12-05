using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cookbook.Models;

namespace Cookbook.Services.EFServices
{
    public interface IDbContextService : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Meal> Meals { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
