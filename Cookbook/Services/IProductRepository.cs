﻿using System;
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
        Product GetByName(string name);
    }
}