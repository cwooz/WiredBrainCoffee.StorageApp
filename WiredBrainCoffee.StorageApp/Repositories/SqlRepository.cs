using System;
using System.Linq;
using System.Collections.Generic;
using WiredBrainCoffee.StorageApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class SqlRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            //item.Id = _dbSet.Any() ? _dbSet.Max(item => item.Id) + 1 : 1;
            _dbSet.Add(item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
