using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeCostControl.Data.Dto;
using RecipeCostControl.Services.Interfaces;

namespace RecipeCostControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal sealed class MeasuremantUnitController(IMeasuremantUnitService service, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<dynamic>> Get()
        {
            var entities = await service.GetAllAsync();
            return Ok(entities.Select(mapper.Map<MeasurementUnitDto>));
        }

        [HttpGet("conversion/{idFrom}/{idTo}")]
        public ActionResult<dynamic> GetConversion(string idFrom, string idTo)
        {
            var entity = service.GetConversionAsync(idFrom, idTo);
            if (entity is null)
                return NotFound();

            return Ok(mapper.Map<MeasurementUnitConversionDto>(entity));
        }

        [HttpGet("conversion/from/{id}")]
        public async Task<ActionResult<dynamic>> GetConversionsFrom(string id)
        {
            var entities = await service.GetAllConversionsFrom(id)
                .ToArrayAsync();

            return Ok(entities.Select(mapper.Map<MeasurementUnitConversionDto>));
        }

        [HttpGet("conversion/to/{id}")]
        public async Task<ActionResult<dynamic>> GetConversionsTo(string id)
        {
            var entities = await service.GetAllConversionsTo(id)
                .ToArrayAsync();

            return Ok(entities.Select(mapper.Map<MeasurementUnitConversionDto>));
        }

        [HttpGet("conversion")]
        public async Task<ActionResult<dynamic>> GetAllConversions()
        {
            var entities = await service.GetAllConversions()
                .ToArrayAsync();
            return Ok(entities.Select(mapper.Map<MeasurementUnitConversionDto>));
        }
    }
}
