using ContactsApi.Models;
using ContactsApi.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactsApi.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity>
            where TEntity : BaseEntity, new()
    {
        protected readonly ApplicationDbContext context;
        protected readonly DbSet<TEntity> EntitySet;

        public EntityRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.EntitySet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> QueryAll()
        {
            return EntitySet.AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.QueryAll().ToListAsync();
        }


        public async Task<TEntity> GetById(Guid id)
        {
            return await this.QueryAll()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            entity.Id = Guid.Empty;
            await EntitySet.AddAsync(entity);
            await context.SaveChangesAsync();
            return await GetById(entity.Id);
        }

        public async Task<TEntity> Update(Guid id, TEntity entity)
        {
            entity.Id = id;
            var existingItem = await EntitySet.FindAsync(id);
            context.Entry(existingItem).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
            return existingItem;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await EntitySet.FindAsync(id);
            return await Delete(entity);
        }

        public async Task<bool> Delete(TEntity entity)
        {
            if (entity == null)
                return false;
            EntitySet.Remove(entity);
            var count = await context.SaveChangesAsync();
            return count > 0;
        }
    }

}
