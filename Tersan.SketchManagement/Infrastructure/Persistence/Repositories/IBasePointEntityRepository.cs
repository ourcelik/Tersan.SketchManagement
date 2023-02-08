using Microsoft.EntityFrameworkCore.Query;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;
using System.Linq.Expressions;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public interface IBasePointEntityRepository<T> :IAsyncRepository<T>,IRepository<T> where T : class
    {
        public Task<T> AddAndScaleAsync(T Entity,Expression<Func<Sketch, bool>>? predicateToFindSketch = null);
        public Task<T> UpdateAndScaleAsync(Expression<Func<Sketch,bool>> predicateToFindSketch,T Entity);
        public Task<T> ScaleAndGetAsync(Expression<Func<T,bool>>? predicate , SizeDto windowSizeDto,Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        public Task<PaginatedItemsViewModel<T>> GetListAndScaleAsync(SizeDto windowSizeDto, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    }
}
