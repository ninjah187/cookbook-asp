using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Services
{
    public interface IProductService
    {
        IProductRepository Repository { get; }
    }
}