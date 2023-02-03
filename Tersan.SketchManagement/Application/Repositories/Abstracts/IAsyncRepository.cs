using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Tersan.SketchManagement.Application.ViewModels;

namespace Tersan.SketchManagement.Application.Repositories.Abstracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, bool enableTracking = true,
                          Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null
        );

        Task<PaginatedItemsViewModel<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                        int index = 0, int size = 10, bool enableTracking = true,
                                        CancellationToken cancellationToken = default);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
