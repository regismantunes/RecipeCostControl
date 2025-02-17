using Microsoft.EntityFrameworkCore;
using RecipeCostControl.Data.Context;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Data.Repositories.Interfaces;

namespace RecipeCostControl.Data.Repositories
{
    public sealed class MeasuremantUnitRepository(AppDbContext context) : IMeasurementUnitRepository
    {
        public async Task<IEnumerable<MeasurementUnit>> GetAllAsync()
        {
            return await context.MeasurementUnits
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<MeasurementUnitConversion> GetAllConversions()
        {
            return context.MeasurementUnitConversions
                .AsNoTracking();
        }
    }
}
