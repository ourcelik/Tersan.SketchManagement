using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Tersan.SketchManagement.Application.Repositories;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public class ShipRepository : EfBaseRepository<Ship, SketchManagementDbContext>, IShipRepository
    {
        public ShipRepository(SketchManagementDbContext context) : base(context)
        {
        }

        public async Task<PaginatedItemsViewModel<ShipSummaryViewModel>> GetAllSummaryAsync(Expression<Func<Ship, bool>>? predicate = null, int pageSize = 10, int pageIndex = 0)
        {
            var query = Query();


            if (predicate != null) query = query.Where(predicate);
            query = query.Include(s => s.ShipStatus);
            if (pageSize == 0) pageSize = 10;
            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            var mappedItems = query.Select((e) => new ShipSummaryViewModel()
            {
                Name = e.Name,
                X = e.X,
                Y = e.Y,
                StatusType = e.ShipStatus.StatusType,
                HexColorCode = e.HexColorCode,
                Width = e.Width,
                Height = e.Height
            });


            var items = await query.ToListAsync();

            var count = items.Count;




            return new PaginatedItemsViewModel<ShipSummaryViewModel>(pageIndex, pageSize, count, mappedItems);
        }


    }

}
