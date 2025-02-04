using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeCostControl.Data.Dto;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeCostControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal sealed class ProductController(IService<Product> service, IMapper mapper)
        : GenericController<Product, ProductDto>(service, mapper)
    {
        
    }
}
