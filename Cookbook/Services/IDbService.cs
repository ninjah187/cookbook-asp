using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Services
{
    public interface IDbService<T>
    {
        void Add(T item);
        void Remove(T item);
    }
}
