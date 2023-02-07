using Tersan.SketchManagement.Application.Repositories;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Infrastructure.Models;

namespace Tersan.SketchManagement.Infrastructure.Repositories
{
    public class ShipStatusRepository : EfBaseRepository<ShipStatus,SketchManagementDbContext>,IShipStatusRepository
    {
        public ShipStatusRepository(SketchManagementDbContext context) : base(context)
        {
            
        }
    }
}
