using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_ECommece.Data
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ECommeceContext _context ;

        public GenericRepository(ECommeceContext context)
        {
            _context = context;
        }
        public ECommeceContext Context
        {
            get { return _context; }
            set { _context = value; }
        }
        public virtual IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(p => p.Id == id);
        }

        public virtual IList<T> Where(Expression<Func<T, bool>> predicate)
        {
            var result = _context.Set<T>().Where(predicate);
            return result.ToList();
        }


        public virtual T Insert(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            return result;
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        // Override olabilmesi için virtual ekliyoruz.
        public virtual int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
