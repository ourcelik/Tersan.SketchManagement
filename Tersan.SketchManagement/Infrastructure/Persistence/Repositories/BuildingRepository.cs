using Microsoft.EntityFrameworkCore;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;
using System.Linq.Expressions;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public class BuildingRepository : BasePointEntityRepository<Building,SketchManagementDbContext>, IBuildingRepository
    {
        ISketchRepository _sketchRepository;

        public BuildingRepository(SketchManagementDbContext context, ISketchRepository sketchRepository) : base(context, sketchRepository)
        {
        }

        public async Task<PaginatedItemsViewModel<BuildingSummaryViewModel>> GetAllSummaryAsync(SizeDto size,Expression<Func<Building, bool>>? predicate = null, int pageSize = 10, int pageIndex = 0)
        {
            var query = Query();


            if (predicate != null) query = query.Where(predicate);

            if (pageSize == 0) pageSize = 10;

            query = query.Include(e => e.Sketch);

            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            var count = items.Count;

            //Scale 
            foreach (var item in items)
            {
                ScaleHelperMethods.ScaleSketchSizeToUserWindow(item, size);
            }

            var mappedItems = items.Select((e) => new BuildingSummaryViewModel()
            {
                Name = e.Name,
                X = e.X,
                Y = e.Y,
                ID = e.ID
            });

            return new PaginatedItemsViewModel<BuildingSummaryViewModel>(pageIndex, pageSize, count, mappedItems);
        }

    }
}
