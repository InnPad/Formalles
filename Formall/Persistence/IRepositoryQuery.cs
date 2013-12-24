using System;
using System.Linq;
using System.Linq.Expressions;

namespace Formall.Persistence
{
    public interface IRepositoryQuery<TResult> : IQueryable<TResult>
        where TResult : class
    {
        IRepositoryQuery<TResult> Include(string path);
        IRepositoryQuery<TResult> Include<TProperty>(Expression<Func<TResult, TProperty>> path);
    }
}
