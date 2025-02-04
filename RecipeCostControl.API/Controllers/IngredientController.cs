using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeCostControl.Data.Dto;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Services.Interfaces;

namespace RecipeCostControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal sealed class IngredientController(IService<Ingredient> service, IMapper mapper)
        : GenericController<Ingredient, IngredientDto>(service, mapper)
    {
        
    }
}
