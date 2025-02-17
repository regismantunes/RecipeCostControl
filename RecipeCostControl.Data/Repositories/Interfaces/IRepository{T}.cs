using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IIdentityEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> ReadAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
