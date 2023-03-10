using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tersan.SketchManagement.Application.Repositories;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public class BuildingRepository : EfBaseRepository<Building, SketchManagementDbContext>, IBuildingRepository
    {
        public BuildingRepository(SketchManagementDbContext context) : base(context)
        {
        }

        public async Task<PaginatedItemsViewModel<BuildingSummaryViewModel>> GetAllSummaryAsync(Expression<Func<Building, bool>>? predicate = null, int pageSize = 10, int pageIndex = 0)
        {
            var query = Query();


            if (predicate != null) query = query.Where(predicate);

            if (pageSize == 0) pageSize = 10;

            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            var mappedItems = query.Select((e) => new BuildingSummaryViewModel()
            {
                Name = e.Name,
                X = e.X,
                Y = e.Y,
                ID = e.ID,
                HexColorCode = e.HexColorCode
            });

            var items = await query.ToListAsync();

            var count = items.Count;

           

            return new PaginatedItemsViewModel<BuildingSummaryViewModel>(pageIndex, pageSize, count, mappedItems);
        }


    }
}
