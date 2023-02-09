using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Tersan.SketchManagement.Application.Repositories;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public class ShipRepository : BasePointEntityRepository<Ship,SketchManagementDbContext>, IShipRepository
    {
        ISketchRepository _sketchRepository;
        public ShipRepository(SketchManagementDbContext context, ISketchRepository sketchRepository) : base(context, sketchRepository)
        {

        }

        public async Task<PaginatedItemsViewModel<ShipSummaryViewModel>> GetAllSummaryAsync(SizeDto size,Expression<Func<Ship, bool>>? predicate = null, int pageSize = 10, int pageIndex = 0)
        {
            var query = Query();


            if (predicate != null) query = query.Where(predicate);

            if (pageSize == 0) pageSize = 10;

            query = query.Include(e => e.Sketch).Include(e => e.ShipStatus);

            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            var count = items.Count;

            //Scale 
            foreach (var item in items)
            {
                ScaleHelperMethods.ScaleSketchSizeToUserWindow(item, size);
            }


            var mappedItems = items.Select((e) => new ShipSummaryViewModel()
            {
                Name = e.Name,
                X = e.X,
                Y = e.Y,
                StatusType = e.ShipStatus.StatusType
            });

            return new PaginatedItemsViewModel<ShipSummaryViewModel>(pageIndex, pageSize, count, mappedItems);
        }


    }

}
