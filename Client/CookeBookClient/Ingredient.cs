using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookClient
{
    public class Ingredient
    {
        public int ingredientId { get; set; }
        public string ingredientName { get; set; }

        public override string? ToString()
        {
            return ingredientName;
        }
    }
}
