using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeCostControl.Data.Dto;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Services.Interfaces;

namespace RecipeCostControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal sealed class RecipeController(IService<Recipe> service, IMapper mapper)
        : GenericController<Recipe, RecipeDto>(service, mapper)
    {
        
    }
}
