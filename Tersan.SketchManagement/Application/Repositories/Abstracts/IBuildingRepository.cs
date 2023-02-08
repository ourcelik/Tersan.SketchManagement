using System.Linq.Expressions;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;
using Tersan.SketchManagement.Infrastructure.Persistence.Repositories;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;

namespace Tersan.SketchManagement.Application.Repositories.Abstracts
{
    public interface IBuildingRepository : IAsyncRepository<Building>, IRepository<Building>,IBasePointEntityRepository<Building>
    {
        Task<PaginatedItemsViewModel<BuildingSummaryViewModel>> GetAllSummaryAsync(SizeDto size,Expression<Func<Building,bool>> predicate,int pageSize,int pageIndex );
     
    }
}
