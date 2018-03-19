using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.GetWay
{
   

    class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _entities = null;
        private readonly DbSet<T> _objectSet;

        public GenericRepository(DbContext entities)
        {
            _entities = entities;
            _objectSet = entities.Set<T>();
        }
       
        public  IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate);
            }

            return _objectSet.AsEnumerable();
        }

        public T Get(Func<T, bool> predicate)
        {
            return _objectSet.First(predicate);
        }
       
        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }
       
        public void Attach(T entity)
        {
            _objectSet.AddOrUpdate(entity);
           
        }
             
        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }
       
        public void DeleteRange(List<T> entity)
        {
            _objectSet.RemoveRange(entity);
        }

        public void AddRange(List<T> entity)
        {
            _objectSet.AddRange(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Where(predicate);
        }
        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _objectSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

       
    }
}
