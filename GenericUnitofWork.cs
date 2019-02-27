﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_ECommece.Data
{
    public class GenericUnitofWork : IDisposable
    {
        private ECommeceContext _context;

        public GenericUnitofWork()
        {
            _context = new ECommeceContext();
        }

        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repository = new GenericRepository<T>(_context);
            repositories.Add(typeof(T), repository);
            return repository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();

        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
