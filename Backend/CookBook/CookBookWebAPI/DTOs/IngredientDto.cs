using CookBookLibrary.Models;

namespace CookBookWebAPI.DTOs
{
    public class IngredientDto
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = null!;
       // public string Measurement { get; set; } = null!;
        //public  virtual ICollection<RecipeIngredientDto> RecipeIngredients { get; set; } = new List<RecipeIngredientDto>();
    }
}
