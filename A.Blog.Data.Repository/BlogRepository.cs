using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace A.Blog.Data.Repository
{
    public class BlogRepository : IRepository
    {
        private readonly BlogEntityContext _context;


        public BlogRepository()
        {
            _context = new BlogEntityContext();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return _context.Set<T>();
        }


        /// <summary>
        /// Gets root queryable for the specified type, expanding the specified include properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> retVal = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                retVal = retVal.Include(includeProperty);
            }

            return retVal;
        }

        public void Dispose()
        {
            if(_context!=null)
                _context.Dispose();
        }
    }
}
