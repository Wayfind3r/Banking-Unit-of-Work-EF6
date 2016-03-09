using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BankingUoW.Interfaces;

namespace BankingUoW.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).AsEnumerable();
        } 
        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
    }
}