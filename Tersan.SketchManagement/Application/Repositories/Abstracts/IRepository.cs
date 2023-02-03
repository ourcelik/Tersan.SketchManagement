using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Tersan.SketchManagement.Application.ViewModels;

namespace Tersan.SketchManagement.Application.Repositories.Abstracts
{
    public interface IRepository<T> where T : class
    {
        T? Get(Expression<Func<T, bool>> predicate);

        PaginatedItemsViewModel<T> GetList(Expression<Func<T, bool>>? predicate = null,
                             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                             int index = 0, int size = 10,
                             bool enableTracking = true);



        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);

    }
}
