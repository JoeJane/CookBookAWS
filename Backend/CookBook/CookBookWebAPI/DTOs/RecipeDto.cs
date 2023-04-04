using CookBookLibrary.Models;

namespace CookBookWebAPI.DTOs
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; } = null!;
        public string? Cuisine { get; set; }
        public string? Description { get; set; }
        public string Instruction { get; set; } = null!;
        public string PrepTime { get; set; } = null!;
        public string? Rating { get; set; }
        public string? PrepVideoUrl { get; set; }
        public byte[]? Image { get; set; }
        public string? Complexity { get; set; }

        public int NumberOfIngredients
        {
            get
            {
                return RecipeIngredients.Count;
            }
        }
        public virtual ICollection<RecipeIngredientDto> RecipeIngredients { get; set; } = new List<RecipeIngredientDto>();
    }
}
