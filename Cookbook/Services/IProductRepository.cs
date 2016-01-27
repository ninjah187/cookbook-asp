using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Models;

namespace Cookbook.Services
{
    public interface IProductRepository : IRepository<Product>
    {
        void ProductSpecificAction();

        void AddToUser(Product product, User user);

        /// <summary>
        /// Checks if product is assigned to specific user and if yes, removes it.
        /// </summary>
        void Remove(int productId, User user);

        Product GetByName(string name);
        ICollection<Product> GetByUser(User user);

        bool Exists(Product product, User user);
    }
}
