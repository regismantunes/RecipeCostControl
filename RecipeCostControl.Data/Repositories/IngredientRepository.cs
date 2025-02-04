using RecipeCostControl.Data.Context;
using RecipeCostControl.Data.Entities;
using RecipeCostControl.Data.Repositories.Interfaces;

namespace RecipeCostControl.Data.Repositories
{
    public sealed class IngredientRepository(MyDbContext context)
        : Repository<Ingredient>(context), IIngredientRepository
    {
        
    }
}
