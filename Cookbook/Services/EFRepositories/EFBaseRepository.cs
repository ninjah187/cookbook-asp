using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Cookbook.Models;
using Ninject;

namespace Cookbook.Services.EFRepositories
{
    public abstract class EFBaseRepository<T> : IRepository<T> where T : class, IModelElement
    {
        protected IDbContextService DbContextService;

        // http://stackoverflow.com/questions/2876616/returning-ienumerablet-vs-iqueryablet
        protected DbSet<T> DbSet;

        protected EFBaseRepository(IDbContextService dbContextService)
        {
            DbContextService = dbContextService;

            DbContextService.Log = s =>
            {
                Debug.WriteLine(s);
            };

            InitializeDbSet();
        }

        private void InitializeDbSet()
        {
            foreach (var propInfo in DbContextService.GetType().GetProperties())
            {
                if (propInfo.PropertyType == typeof (DbSet<T>))
                {
                    DbSet = (DbSet<T>) propInfo.GetValue(DbContextService);
                    return;
                }
            }
        }

        public void Add(T item)
        {
            DbSet.Add(item);
            DbContextService.SaveChanges();
        }

        public abstract void Add(dynamic itemInfo);

        public void Remove(int id)
        {
            var item = Get(id);
            DbSet.Remove(item);
            DbContextService.SaveChanges();
        }

        public abstract void Update(int id, T newItem);

        public abstract void Update(T item, T newItem);

        public T Get(int id)
        {
            var item = DbSet.Single(i => i.Id == id);
            return item;
        }

        public IEnumerable<T> Get(IEnumerable<int> ids)
        {
            // TODO: consider which way is better - linq or loop
            // TODO: to do it, check how many queries are sent to db
            var output = DbSet.Where(i => ids.Contains(i.Id)).ToList();
            //foreach (var id in ids)
            //{
            //    output.Add(Get(id));
            //}
            return output;
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<T> Yield(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                yield return Get(id);
            }
        }

        public IEnumerable<T> YieldAll()
        {
            foreach (var item in DbSet)
            {
                yield return item;
            }
        }

        public virtual bool Exists(T item)
        {
            return DbSet.Contains(item);
        }
    }
}