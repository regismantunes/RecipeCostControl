using AutoMapper;
using RecipeCostControl.Data.Dto;
using RecipeCostControl.Data.Entities;

namespace RecipeCostControl.Data.Map
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<MeasurementUnit, MeasurementUnitDto>();
            CreateMap<MeasurementUnitConversion,  MeasurementUnitConversionDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Packaging, PackagingDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeItem, RecipeItemDto>();
        }
    }
}
