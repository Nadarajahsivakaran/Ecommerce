using Microsoft.EntityFrameworkCore;
using Product.DataAccess.IRepository;
using System.Linq.Expressions;


namespace Product.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            this.dbSet = applicationDbContext.Set<T>();
        }
        public async Task<T> Create(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await Save();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var record = await dbSet.Where(predicate).FirstOrDefaultAsync();
                if (record == null) return false;

                var isDeletedProperty = record.GetType().GetProperty("IsDelete");
                if (isDeletedProperty != null)
                {
                    isDeletedProperty.SetValue(record, 1);
                    await Save();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll(string[]? includeProperties = null)
        {
            try
            {
                IQueryable<T> query = dbSet;

                // Define a lambda expression for the IsDelete condition
                var parameter = Expression.Parameter(typeof(T), "x");
                var isDeleteProperty = Expression.Property(parameter, "IsDelete");
                var constantZero = Expression.Constant(0, typeof(int?));

                // Compare nullable integers with Equals
                var isDeleteEqualsZero = Expression.Equal(isDeleteProperty, constantZero);

                // Combine the lambda expression with the query
                var lambda = Expression.Lambda<Func<T, bool>>(isDeleteEqualsZero, parameter);
                query = query.Where(lambda);

                if (includeProperties != null && includeProperties.Length > 0)
                {
                    if (includeProperties != null && includeProperties.Length > 0)
                    {
                        foreach (string includeProperty in includeProperties)
                        {
                            query = query.Include(includeProperty);
                        }
                    }
                }
                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate, string[]? includeProperties = null)
        {
            try
            {
                IQueryable<T> query = dbSet;

                // Define a lambda expression for the IsDelete condition
                var parameter = Expression.Parameter(typeof(T), "x");
                var isDeleteProperty = Expression.Property(parameter, "IsDelete");
                var constantZero = Expression.Constant(0, typeof(int?));

                // Compare nullable integers with Equals
                var isDeleteEqualsZero = Expression.Equal(isDeleteProperty, constantZero);

                // Combine the lambda expression with the query
                var lambda = Expression.Lambda<Func<T, bool>>(isDeleteEqualsZero, parameter);
                query = query.Where(lambda);

                if (predicate != null)
                    query = query.Where(predicate);

                if (includeProperties != null && includeProperties.Length > 0)
                {
                    foreach (string includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await dbSet.Where(predicate).AnyAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Save()
        {
            try
            {
                await applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                dbSet.Update(entity);
                await Save();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
