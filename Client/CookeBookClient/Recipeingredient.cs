using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CookBookClient
{
    public class Recipeingredient
    {
        public string measurement { get; set; }
        public Ingredient ingredient { get; set; }

        public override string? ToString()
        {
            return measurement + "  " + ingredient.ingredientName;
        }

        public Recipeingredient(string measurement, Ingredient ingredient)
        {
            this.measurement = measurement;
            this.ingredient = ingredient;
        }
    }

    public class IngredientMeasurement
    { 
        public int ingredientId {get;set;}
        public string measurement { get; set; }

        public IngredientMeasurement(int ingredientId, string measurement)
        {
            this.ingredientId = ingredientId;
            this.measurement = measurement;
        }
    }
}
