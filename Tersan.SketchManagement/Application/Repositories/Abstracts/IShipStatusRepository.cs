using Tersan.SketchManagement.Infrastructure.Models;

namespace Tersan.SketchManagement.Application.Repositories.Abstracts
{
    public interface IShipStatusRepository : IAsyncRepository<ShipStatus>, IRepository<ShipStatus>
    {
        
    }
}
