﻿using Microsoft.EntityFrameworkCore;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Data.Repositories.Interfaces;
using RecipeCostControl.Services.Interfaces;

namespace RecipeCostControl.Services
{
    public class MeasuremantUnitService(IMeasurementUnitRepository repository) : IMeasuremantUnitService
    {
        public async Task<IEnumerable<MeasurementUnit>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public IQueryable<MeasurementUnitConversion> GetAllConversionsFrom(string id)
        {
            return repository.GetAllConversions()
                .Where(x => x.MeasurementUnitFromId.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public IQueryable<MeasurementUnitConversion> GetAllConversionsTo(string id)
        {
            return repository.GetAllConversions()
                .Where(x => x.MeasurementUnitToId.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public Task<MeasurementUnitConversion?> GetConversionAsync(string idFrom, string idTo)
        {
            return GetAllConversionsFrom(idFrom)
                .Where(x => x.MeasurementUnitTo.Id.Equals(idTo, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefaultAsync();
        }

        public IQueryable<MeasurementUnitConversion> GetAllConversions()
        {
            return repository.GetAllConversions();
        }
    }
}
