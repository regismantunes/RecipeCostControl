using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Repositories.Interfaces
{
    public interface IMeasurementUnitRepository
    {
        Task<IEnumerable<MeasurementUnit>> GetAllAsync();

        IQueryable<MeasurementUnitConversion> GetAllConversions();
    }
}
