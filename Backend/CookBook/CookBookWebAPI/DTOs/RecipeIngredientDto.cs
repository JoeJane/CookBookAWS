using CookBookLibrary.Models;

namespace CookBookWebAPI.DTOs
{
    public class RecipeIngredientDto
    {
    
        public string Measurement { get; set; } = null!;
        public virtual IngredientDto Ingredient { get; set; } = null!;
    }
}
