using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace A.Blog.Data
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
    }
}
