using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IIdentityEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> ReadAsync(int id);
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
