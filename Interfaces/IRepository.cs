using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BankingUoW.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        void Add(TEntity tEntity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
    }
}