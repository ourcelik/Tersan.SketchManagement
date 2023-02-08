using System.Linq.Expressions;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship;

namespace Tersan.SketchManagement.Application.Repositories.Abstracts
{
    public interface IShipRepository : IAsyncRepository<Ship>, IRepository<Ship>
    {
        Task<PaginatedItemsViewModel<ShipSummaryViewModel>> GetAllSummaryAsync(Expression<Func<Ship, bool>> predicate, int pageSize, int pageIndex);
    }
}
