using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace Cookbook.Services
{
    public class ProductService : IProductService
    {
        [Inject]
        public IProductRepository Repository { get; set; }
    }
}