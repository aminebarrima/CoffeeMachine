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
        /// <summary>
        /// Get all the list
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate);
            }

            return _objectSet.AsEnumerable();
        }
        /// <summary>
        /// Get a certain element of the list
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T Get(Func<T, bool> predicate)
        {
            return _objectSet.First(predicate);
        }
        /// <summary>
        /// Add a new element to the list
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }
        /// <summary>
        /// Update a certain element
        /// </summary>
        /// <param name="entity"></param>
        public void Attach(T entity)
        {
            _objectSet.AddOrUpdate(entity);
            //_objectSet.Attach(entity);
            //_entities.Entry(entity).State = EntityState.Modified;
            //DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            //dbEntityEntry.State = EntityState.Modified;
        }
        /// <summary>
        /// Delete an element from the list
        /// </summary>
        /// <param name="entity"></param>
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
