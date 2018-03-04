using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.GetWay;
namespace CoffeeMachine.GetWay.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoffeeMachineDbContext _entities = null;
        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public UnitOfWork(CoffeeMachineDbContext entities)
        {
            this._entities = entities;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)) == true)
            {
                return Repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new GenericRepository<T>(_entities);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges()
        {
            _entities.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
