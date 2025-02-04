using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeCostControl.Data.Dto;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Services.Interfaces;

namespace RecipeCostControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal sealed class PackagingController(IService<Packaging> service, IMapper mapper)
        : GenericController<Packaging, PackagingDto>(service, mapper)
    {
        
    }
}
