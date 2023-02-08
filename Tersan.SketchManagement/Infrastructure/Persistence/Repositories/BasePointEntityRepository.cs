using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Tersan.SketchManagement.Application.Repositories;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Tersan.SketchManagement.Infrastructure.Models;
using Tersan.SketchManagement.Infrastructure.Persistence.Dtos;
using System.Linq.Expressions;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public class BasePointEntityRepository<T, TDbContext> : EfBaseRepository<T, TDbContext>, IBasePointEntityRepository<T> where T : class where TDbContext : DbContext
    {
        ISketchRepository _sketchRepository;
        public BasePointEntityRepository(TDbContext context, ISketchRepository sketchRepository) : base(context)
        {
            _sketchRepository = sketchRepository;
        }

        public async Task<T> AddAndScaleAsync(T Entity,Expression<Func<Sketch, bool>>? predicateToFindSketch)
        {
            var size = await _sketchRepository.GetSizeAsync(predicateToFindSketch);
            
            dynamic entity = Entity;

            SizeDto sizeDto = new SizeDto()
            {
                Height = entity.WindowHeight,
                Width =  entity.WindowWidth
            };

            ScaleHelperMethods.ScalePointSizeToSketch(Entity, size);

            var result = await AddAsync(Entity);
            
            ScaleHelperMethods.ScaleSketchSizeToUserWindow(result,sizeDto);

            return result;
        }

        public async Task<T> UpdateAndScaleAsync(Expression<Func<Sketch,bool>> predicateToFindSketch,T Entity)
        {
            dynamic entity = Entity;

            SizeDto sizeDto = new SizeDto()
            {
                Height = entity.WindowHeight,
                Width =  entity.WindowWidth
            };
            
            var size = await _sketchRepository.GetSizeAsync(predicateToFindSketch);
            ScaleHelperMethods.ScalePointSizeToSketch(Entity, size);
            
            var result = await UpdateAsync(Entity);

            ScaleHelperMethods.ScaleSketchSizeToUserWindow(result,sizeDto);

            return result;
        }

        public async Task<T> ScaleAndGetAsync(Expression<Func<T,bool>>? predicate , SizeDto windowSizeDto,Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var entity = await GetAsync(predicate,include: include);

             if (entity == null)
            {
                throw new Exception("Building not found");
            }

            ScaleHelperMethods.ScaleSketchSizeToUserWindow(entity,windowSizeDto);

            return entity;
        }

        public async Task<PaginatedItemsViewModel<T>> GetListAndScaleAsync(SizeDto windowSizeDto, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
             var buildings = await GetListAsync(include:include);

            foreach (var building in buildings.Data)
            {
                ScaleHelperMethods.ScaleSketchSizeToUserWindow(building,windowSizeDto);
            }

            return buildings;
        }

    }
}
