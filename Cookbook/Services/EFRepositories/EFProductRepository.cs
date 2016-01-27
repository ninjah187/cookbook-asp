using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Cookbook.Models;
using Ninject;

namespace Cookbook.Services.EFRepositories
{
    public class EFProductRepository : EFBaseRepository<Product>, IProductRepository
    {
        [Inject]
        public EFProductRepository(IDbContextService dbContextService)
            : base(dbContextService)
        {
        }

        public override void Add(dynamic itemInfo)
        {
            var item = new Product()
            {
                Name = itemInfo.Name
                //KcalPer100Grams = itemInfo.KcalPer100Grams,
                //User = itemInfo.User
            };
            DbSet.Add(item);
            DbContextService.SaveChanges();
        }

        public void AddToUser(Product product, User user)
        {
            if (Exists(product, user))
            {
                throw new InvalidOperationException("Such product already exists.");
            }

            product.User = DbContextService.Users.Single(u => u.Id == user.Id);

            DbSet.Add(product);
            DbContextService.SaveChanges();
        }

        public void Remove(int productId, User user)
        {
            var product = Get(productId);

            if (product.User.Id != user.Id)
            {
                throw new InvalidOperationException("Product doesn't belong to specific user.");
            }

            product.User = null;

            DbSet.Remove(product);
            DbContextService.SaveChanges();
        }

        public override void Update(int id, Product newItem)
        {
            var item = Get(id);
            item.Name = newItem.Name;
            
            item.KcalPer100Grams = item.KcalPer100Grams;

            if (newItem.User != null)
            {
                item.User.Id = newItem.User.Id;
            }

            DbContextService.SaveChanges();
        }

        public override void Update(Product item, Product newItem)
        {
            throw new NotImplementedException();
        }

        public void ProductSpecificAction()
        {
            throw new NotImplementedException();
        }

        public Product GetByName(string name)
        {
            return DbSet.SingleOrDefault(p => p.Name == name);
        }

        public ICollection<Product> GetByUser(User user)
        {
            return DbSet.Where(p => p.User.Id == user.Id).ToList();
        }

        public override bool Exists(Product item)
        {
            return DbSet.SingleOrDefault(p => p.Id == item.Id || p.Name == item.Name) != null;
        }

        public bool Exists(Product item, User user)
        {
            return DbSet.SingleOrDefault(p => (p.Id == item.Id || p.Name == item.Name) && p.User.Id == user.Id) != null;
        }
    }
}