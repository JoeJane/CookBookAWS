namespace CookBookWebAPI.DTOs
{
    public class RecipeIngredientCreationDto
    {
        public int IngredientId { get; set; }
        public string Measurement { get; set; } = null!;

    }
}
