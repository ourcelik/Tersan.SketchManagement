using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Application.ViewModels;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Tersan.SketchManagement.Application.Repositories
{
    public class EfBaseRepository<TEntity,TContext> : IAsyncRepository<TEntity>,IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
            TContext Context { get; }

            public EfBaseRepository(TContext context)
            {
                Context = context;
            }

            public TEntity Add(TEntity entity)
            {
                Context.Entry(entity).State = EntityState.Added;
                Context.SaveChanges();

                return entity;
            }

            public async Task<TEntity> AddAsync(TEntity entity)
            {
                Context.Entry(entity).State = EntityState.Added;
                await Context.SaveChangesAsync();

                return entity;
            }

            public TEntity Delete(TEntity entity)
            {
                Context.Entry(entity).State = EntityState.Deleted;
                Context.SaveChanges();

                return entity;
            }

            public async Task<TEntity> DeleteAsync(TEntity entity)
            {
                Context.Entry(entity).State = EntityState.Deleted;
                await Context.SaveChangesAsync();

                return entity;
            }

            public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
            {
                TEntity? result = Context.Set<TEntity>().FirstOrDefault(predicate);

                return result;
            }

            public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, bool enableTracking = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
            {
                IQueryable<TEntity> queryable = Context.Set<TEntity>();
                if (!enableTracking) queryable = queryable.AsNoTracking();
                if (include != null) queryable = include(queryable);

                TEntity? result = await queryable.FirstOrDefaultAsync(predicate);


                return result;
            }

            public PaginatedItemsViewModel<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
            {
                //GetList

                IQueryable<TEntity> queryable = Context.Set<TEntity>();
                if (!enableTracking) queryable = queryable.AsNoTracking();
                if (include != null) queryable = include(queryable);
                if (predicate != null) queryable = queryable.Where(predicate);
                if (orderBy != null) queryable = orderBy(queryable);

                // Paginate
                int totalItems = queryable.Count();
                queryable = queryable.Skip(index * size).Take(size);

                // Execute
                List<TEntity> items = queryable.ToList();

                // Return

                return new PaginatedItemsViewModel<TEntity>(index, size, totalItems, items);


            }

            public async Task<PaginatedItemsViewModel<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
            {
                IQueryable<TEntity> queryable = Context.Set<TEntity>();
                if (!enableTracking) queryable = queryable.AsNoTracking();
                if (include != null) queryable = include(queryable);
                if (predicate != null) queryable = queryable.Where(predicate);
                if (orderBy != null) queryable = orderBy(queryable);

                if (size != 0)
                {
                queryable = queryable.Skip(index * size).Take(size);
                    size = 10;
                }
                int totalItems = await queryable.CountAsync();

                // Execute

                List<TEntity> items = await queryable.ToListAsync();

                // Return

                return new PaginatedItemsViewModel<TEntity>(index, size, totalItems, items);

            }

            public TEntity Update(TEntity entity)
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();

                return entity;
            }

            public async Task<TEntity> UpdateAsync(TEntity entity)
            {
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();

                return entity;
            }

            public IQueryable<TEntity> Query()
            {
                return Context.Set<TEntity>();
            }

            public IQueryable<TEntity> QueryAsNoTracking()
            {
                return Context.Set<TEntity>();
            }

    }
}
