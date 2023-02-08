using System.Linq.Expressions;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;

namespace Tersan.SketchManagement.Application.Repositories.Abstracts
{
    public interface IBuildingRepository : IAsyncRepository<Building>, IRepository<Building>
    {
        Task<PaginatedItemsViewModel<BuildingSummaryViewModel>> GetAllSummaryAsync(Expression<Func<Building,bool>> predicate,int pageSize,int pageIndex );
    }
}
