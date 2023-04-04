using CookBookLibrary.Models;

namespace CookBookWebAPI.DTOs
{
    public class RecipeIngredientPatchDto
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string Measurement { get; set; } = null!;

    }
}
