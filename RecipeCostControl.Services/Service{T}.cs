using RecipeCostControl.Data.Entities;
using RecipeCostControl.Data.Repositories.Interfaces;
using RecipeCostControl.Services.Interfaces;

namespace RecipeCostControl.Services
{
    public class Service<T>(IRepository<T> repository) : IService<T> where T : class, IIdentityEntity
    {
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await repository.ReadAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            return await repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
