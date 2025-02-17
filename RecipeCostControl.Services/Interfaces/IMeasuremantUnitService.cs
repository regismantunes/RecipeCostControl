using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Services.Interfaces
{
    public interface IMeasuremantUnitService
    {
        Task<IEnumerable<MeasurementUnit>> GetAllAsync();

        IQueryable<MeasurementUnitConversion> GetAllConversions();
        
        IQueryable<MeasurementUnitConversion> GetAllConversionsFrom(string id);
        
        IQueryable<MeasurementUnitConversion> GetAllConversionsTo(string id);

        MeasurementUnitConversion? GetConversionAsync(string idFrom, string idTo);
    }
}