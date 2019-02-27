using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_ECommece.Data
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        IList<T> Where(Expression<Func<T, bool>> predicate);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
