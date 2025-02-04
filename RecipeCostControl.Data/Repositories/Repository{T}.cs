using Microsoft.EntityFrameworkCore;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Data.Extensions;
using RecipeCostControl.Data.Repositories.Interfaces;

namespace RecipeCostControl.Data.Repositories
{
    public class Repository<T>(DbContext context) : IRepository<T> where T : class, IIdentityEntity, new()
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task DeleteAsync(int id)
        {
            var entity = new T() { Id = id };
            var myEntity = await ReadAsync(entity);
            _dbSet.Remove(myEntity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            var inserted = await _dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return inserted.Entity;
        }

        public async Task<T?> ReadAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null)
                return null;

            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        private async Task<T> ReadAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity.Id, nameof(entity.Id));

            return await ReadAsync(entity.Id.Value) ?? throw new Exception($"{typeof(T).Name} with Id {entity.Id} not found.");
        }

        public async Task UpdateAsync(T entity)
        {
            var myEntity = await ReadAsync(entity);
            myEntity.CopyFrom(entity);

            _dbSet.Update(myEntity);
            await context.SaveChangesAsync();
        }
    }
}
