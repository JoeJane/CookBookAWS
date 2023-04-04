using CookBookLibrary.Models;

namespace CookBookWebAPI.Services
{
    public interface ICookBookRepository
    {
        //Recipe Related queries
        IEnumerable<Recipe> GetRecipeByCuisine(string cuisine); 
        IEnumerable<Recipe> GetRecipes();
        Task<bool> RecipeExistsAsync(int recipeId);
        Task AddRecipe(Recipe newRecipe);     
        Task<Recipe> GetRecipeById(int id);
        Task<RecipeIngredient> GetRecipeIngredientById(int recipeId, int ingredientId);
        void DeleteRecipe(Recipe recipe);

        //Ingredient Related queries
        IEnumerable<Ingredient> GetIngredients();
        Task<Ingredient> GetIngredientById(int id);
        Task<bool> IngredientExistsAsync(int ingredientId);
        Task AddIngredient(Ingredient newIngredient);
        Task<bool> IngredientNameExistsAsync(string ingredientName);        
        void DeleteIngredient(Ingredient ingredient);


        Task<bool> SaveAsync();
    }
}
