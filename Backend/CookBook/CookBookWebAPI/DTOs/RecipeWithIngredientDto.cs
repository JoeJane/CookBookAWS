namespace CookBookWebAPI.DTOs
{
    public class RecipeWithIngredientDto
    {
        public RecipeDto recipeDetail { get; set; }
        public Dictionary<IngredientDto,String> Ingredients{ get; set; }

    }
}
