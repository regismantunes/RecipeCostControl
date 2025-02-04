using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeCostControl.API.Controllers
{
    internal abstract class GenericController<T,TDto>(IService<T> service, IMapper mapper) : ControllerBase
        where T : class, IIdentityEntity
    {
        // GET: api/<TController>
        [HttpGet]
        public async Task<ActionResult<dynamic>> Get()
        {
            var entities = await service.GetAllAsync();
            return Ok(entities.Select(mapper.Map<TDto>));
        }

        // GET api/<TController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> Get(int id)
        {
            var entity = await service.GetByIdAsync(id);
            if (entity is null)
                return NotFound();

            return Ok(mapper.Map<TDto>(entity));
        }

        // POST api/<TController>
        [HttpPost]
        public async Task<ActionResult<dynamic>> Post([FromBody] TDto value)
        {
            var entity = mapper.Map<T>(value);
            entity = await service.InsertAsync(entity);
            return Ok(entity);
        }

        // PUT api/<TController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TDto value)
        {
            var entity = mapper.Map<T>(value);
            entity.Id = id;
            await service.UpdateAsync(entity);
            return Ok();
        }

        // DELETE api/<TController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }
    }
}
