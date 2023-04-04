using System;
using System.Collections.Generic;

namespace CookBookLibrary.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = null!;

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
