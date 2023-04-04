using CookBookLibrary.Models;
using CookBookWebAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CookBookWebAPI.Services
{
    public class CookBookRepository : ICookBookRepository
    {
        private CookBookDBContext dBContext;

        public CookBookRepository(CookBookDBContext context)
        {
            this.dBContext = context;
        }
        public async Task<bool> RecipeExistsAsync(int recipeId)
        {
            return await dBContext.Recipes.AnyAsync<Recipe>(i => i.RecipeId == recipeId);
        }
        public async Task<bool> IngredientExistsAsync(int ingredientId)
        {
            return await dBContext.Ingredients.AnyAsync<Ingredient>(i => i.IngredientId == ingredientId);
        }
        public  IEnumerable<Recipe> GetRecipeByCuisine(string cuisine)
        {    
            IEnumerable < Recipe > recipes= dBContext.Recipes.Include(recipe => recipe.RecipeIngredients)
                .ThenInclude(recipeIngredient => recipeIngredient.Ingredient).Where(c => c.Cuisine == cuisine);          
            return recipes;
        }
        public  async Task AddRecipe(Recipe newRecipe)
        {          
           dBContext.Recipes.Add(newRecipe);
           await dBContext.SaveChangesAsync();
        }
        public async Task<Recipe> GetRecipeById(int id)
        {
            IEnumerable<Recipe> recipes = dBContext.Recipes.Include(recipe => recipe.RecipeIngredients)
                .ThenInclude(recipeIngredient => recipeIngredient.Ingredient).Where(c => c.RecipeId == id);

            return recipes.FirstOrDefault();
        }
            
        public void DeleteRecipe(Recipe recipe)
        {
            foreach(RecipeIngredient ingredient in recipe.RecipeIngredients)
            {
                dBContext.RecipeIngredients.Remove(ingredient);
            }
            dBContext.Recipes.Remove(recipe);
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            IEnumerable<Recipe> recipes = dBContext.Recipes.Include(recipe => recipe.RecipeIngredients)
                  .ThenInclude(recipeIngredient => recipeIngredient.Ingredient);
            return recipes;
        }

        public async Task<RecipeIngredient> GetRecipeIngredientById(int recipeId, int ingredientId)
        {
            IEnumerable<RecipeIngredient> recipeIngredient = dBContext.RecipeIngredients.Where(c => c.RecipeId == recipeId && c.IngredientId == ingredientId);
            return recipeIngredient.FirstOrDefault();
        }


        public IEnumerable<Ingredient> GetIngredients()
        {
            IEnumerable<Ingredient> ingredients = dBContext.Ingredients;
            return ingredients;
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            IEnumerable<Ingredient> ingredients = dBContext.Ingredients.Where(c => c.IngredientId == id);
            return ingredients.FirstOrDefault();
        }

        public async Task AddIngredient(Ingredient newIngredient)
        {
            if (!await IngredientNameExistsAsync(newIngredient.IngredientName))            {
                dBContext.Ingredients.Add(newIngredient);
                await dBContext.SaveChangesAsync();
            }
        }

        public async Task<bool> IngredientNameExistsAsync(string ingredientName)
        {
            return await dBContext.Ingredients.AnyAsync<Ingredient>(i => i.IngredientName == ingredientName);
        }

        public  bool IngredientExistsinJoinTableAsync(int ingredientId)
        {
            IEnumerable<RecipeIngredient> recipeIngredient = dBContext.RecipeIngredients.Where(c=> c.IngredientId == ingredientId);
            if(recipeIngredient.Any())
            {
                return true;
            }
            return false;
        }
        public  void DeleteIngredient(Ingredient ingredient)
        {
            if (!IngredientExistsinJoinTableAsync(ingredient.IngredientId)) { 
                dBContext.Ingredients.Remove(ingredient);
             }
        }
        public async Task<bool> SaveAsync()
        {
            return (await dBContext.SaveChangesAsync()) > 0;
        }
    }
}
