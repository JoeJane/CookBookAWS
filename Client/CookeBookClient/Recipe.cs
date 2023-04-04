using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookClient
{
    public class Recipe
    {
            public int recipeId { get; set; }
            public string recipeName { get; set; }
            public string cuisine { get; set; }
            public string description { get; set; }
            public string instruction { get; set; }
            public string prepTime { get; set; }
            public string rating { get; set; }
            public string prepVideoUrl { get; set; }
            public string image { get; set; }
            public string complexity { get; set; }
            public int numberOfIngredients { get; set; }
            public List<Recipeingredient> recipeIngredients { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return recipeName;
        }
        public Recipe() { }
        public Recipe (int recipeId, string recipeName, string cuisine, string description, string instruction, string prepTime, string rating, string prepVideoUrl, string complexity, int numberOfIngredients, List<Recipeingredient> recipeIngredients)
        {
            this.recipeId = recipeId;
            this.recipeName = recipeName;
            this.cuisine = cuisine;
            this.description = description;
            this.instruction = instruction;
            this.prepTime = prepTime;
            this.rating = rating;
            this.prepVideoUrl = prepVideoUrl;
            this.complexity = complexity;
            this.numberOfIngredients = numberOfIngredients;
            this.recipeIngredients = recipeIngredients;
        }
    }

    public class RecipeCreation
    {

        public string RecipeName { get; set; } = null!;
        public string? Cuisine { get; set; }
        public string? Description { get; set; }
        public string Instruction { get; set; } = null!;
        public string PrepTime { get; set; } = null!;
        public string? Rating { get; set; }
        public string? PrepVideoUrl { get; set; }
        public byte[]? Image { get; set; }
        public string? Complexity { get; set; }

        public List<IngredientMeasurement> RecipeIngredients { get; set; }
        public RecipeCreation() { }
        public RecipeCreation(string recipeName, string? cuisine, string? description, string instruction, string prepTime, string? rating, string? prepVideoUrl, string? complexity, List<IngredientMeasurement> recipeIngredients)
        {
            RecipeName = recipeName;
            Cuisine = cuisine;
            Description = description;
            Instruction = instruction;
            PrepTime = prepTime;
            Rating = rating;
            PrepVideoUrl = prepVideoUrl;
            Complexity = complexity;
            RecipeIngredients = recipeIngredients;
        }
    }

}
