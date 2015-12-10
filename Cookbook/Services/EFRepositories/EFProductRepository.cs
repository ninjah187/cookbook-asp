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
    }
}