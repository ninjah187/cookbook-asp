using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Cookbook.Models;
using Ninject;

namespace Cookbook.Services.EFServices
{
    public class EFProductService : IProductService
    {
        private IDbContextService _dbContextService;

        [Inject]
        public EFProductService(IDbContextService dbContextService)
        {
            _dbContextService = dbContextService;
        }

        public void Add(Product item)
        {
            _dbContextService.Products.Add(item);
            _dbContextService.SaveChanges();
        }

        public void Add(dynamic itemInfo)
        {
            var product = new Product()
            {
                Name = itemInfo.Name,
                KcalPer100Grams = itemInfo.KcalPer100Grams,
                User = itemInfo.User.Id
            };

            Add(product);
        }

        public void Remove(int id)
        {
            var product = Get(id);
            _dbContextService.Products.Remove(product);
            _dbContextService.SaveChanges();
        }

        public void Update(int id, Product newItem)
        {
            throw new NotImplementedException();
        }

        public void Update(Product item, Product newItem)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            var product = _dbContextService.Products.Single(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> GetItems(IEnumerable<int> id)
        {
            var items = new List<Product>();
            foreach (var item in _dbContextService.Products)
            {
                items.Add(item);
            }
            return items;
        }

        public IEnumerable<Product> YieldItems(IEnumerable<int> id)
        {
            foreach (var item in _dbContextService.Products)
            {
                
            }
        }
    }
}