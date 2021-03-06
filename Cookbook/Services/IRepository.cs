﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Services
{
    public interface IRepository<T>
    {
        // TODO: use IProductService etc or just use this generic class?

        void Add(T item);
        void Add(dynamic itemInfo);
        void Remove(int id);
        void Update(int id, T newItem);
        void Update(T item, T newItem);
        T Get(int id);
        IEnumerable<T> Get(IEnumerable<int> ids);
        IEnumerable<T> GetAll();
        IEnumerable<T> Yield(IEnumerable<int> ids);
        IEnumerable<T> YieldAll();
        bool Exists(T item);
    }
}
