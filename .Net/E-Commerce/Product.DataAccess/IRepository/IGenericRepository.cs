using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.DataAccess.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string[]? includeProperties = null);

        Task<T> GetById(Expression<Func<T,bool>> predicate, string[]? includeProperties = null);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(Expression<Func<T, bool>> predicate);

        Task<bool> IsExist(Expression<Func<T, bool>> predicate);

        Task Save();
    }
}
