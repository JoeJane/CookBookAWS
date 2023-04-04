using System;
using System.Collections.Generic;

namespace CookBookLibrary.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

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

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
