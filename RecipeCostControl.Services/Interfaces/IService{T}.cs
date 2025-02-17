namespace RecipeCostControl.Services.Interfaces
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        
        Task<T?> GetByIdAsync(int id);

        Task<T> InsertAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);
    }
}
