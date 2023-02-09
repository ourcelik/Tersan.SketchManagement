using System.Linq.Expressions;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;
using Tersan.SketchManagement.Infrastructure.Persistence.Repositories;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship;

namespace Tersan.SketchManagement.Application.Repositories.Abstracts
{
    public interface IShipRepository : IAsyncRepository<Ship>, IRepository<Ship>,IBasePointEntityRepository<Ship>
    {
        Task<PaginatedItemsViewModel<ShipSummaryViewModel>> GetAllSummaryAsync(SizeDto size,Expression<Func<Ship, bool>>? predicate = null, int pageSize = 10, int pageIndex = 0);
    }
}
