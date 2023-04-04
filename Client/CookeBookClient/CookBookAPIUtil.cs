using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CookBookClient
{
    public static class CookBookAPIUtil
    {
        public static HttpClient client;
        static CookBookAPIUtil()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://34.111.95.238.nip.io/cookbookproxy/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("apikey", "wXGdnZ0HR8A3Id5hzCG4wsmlUeqvxwCURfHxuPPmXIhyFy6N");
        }

        internal async static Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            IEnumerable<Ingredient> ingredients = Enumerable.Empty<Ingredient>();
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync("api/ingredients");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    ingredients = JsonConvert.DeserializeObject<IEnumerable<Ingredient>>(json);
                    if (ingredients.Count() > 0)
                    {
                        Trace.WriteLine($"Get All Ingredients Successful!");
                    }
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                throw new Exception(ex.Message);
            }
            return ingredients;
        }

        internal async static Task<Ingredient> GetIngredientById(int ingredientId)
        {
            Ingredient ingredient = new Ingredient();
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync($"api/Ingredient/{ingredientId}");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    ingredient = JsonConvert.DeserializeObject<Ingredient>(json);
                    Trace.WriteLine($"Get Ingredient by ID is Successful!");

                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                throw new Exception(ex.Message);
            }
            return ingredient;
        }

        internal async static Task<String> AddIngredient(Ingredient ingredient)
        {
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.PostAsJsonAsync("api/Ingredient/", ingredient);

                Trace.WriteLine($"Status From POST {response.StatusCode}");
                response.EnsureSuccessStatusCode();
                Trace.WriteLine($"Added resources at {response.Headers.Location}");
                json = await response.Content.ReadAsStringAsync();
                Trace.WriteLine($"Ingredient Added Successfully");
                return "Ingredient Added Successfully";

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                return "Something went wrong! Please try again";
            }
        }


        internal async static Task<String> UpdateIngredient(Ingredient ingredient)
        {
            try
            {
                string json;
                HttpResponseMessage response;
                Ingredient updated = new Ingredient();
                updated.ingredientName = ingredient.ingredientName;
                json = JsonConvert.SerializeObject(updated);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PutAsync($"api/Ingredient/{ingredient.ingredientId}", content);

                Trace.WriteLine($"Status From PUT {response.StatusCode}");
                response.EnsureSuccessStatusCode();
                Trace.WriteLine($"Updated Ingredient!");
                json = await response.Content.ReadAsStringAsync();

                return "Ingredient Updated Successfully";

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                return "Something went wrong! Please try again";
            }
        }


        internal async static Task<String> DeleteIngredient(int ingredientId)
        {
            try
            {
                HttpResponseMessage response;
                response = await client.DeleteAsync($"api/Ingredient/{ingredientId}");

                Trace.WriteLine($"Status From DELETE {response.StatusCode}");
                response.EnsureSuccessStatusCode();
                Trace.WriteLine($"Deleted Ingredient!");
                return "Ingredient Deleted Successfully";

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                return "Something went wrong! Please try again";
            }
        }

        internal async static Task<String> PatchIngredient(Ingredient ingredient)
        {
            try
            {
                var patchDoc = new JsonPatchDocument<Ingredient>();
                patchDoc.Replace(i => i.ingredientName, ingredient.ingredientName);
                var serializedDoc = JsonConvert.SerializeObject(patchDoc);
                var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");
                Trace.WriteLine($"Request Content {requestContent.ReadAsStringAsync().Result}");
                int id = ingredient.ingredientId;
                var uri = Path.Combine("api", "ingredient", id.ToString());
                var response = await client.PatchAsync(uri, requestContent);

                response.EnsureSuccessStatusCode();
                Trace.WriteLine($"Patch Successful for Ingredient!");
                return "Ingredient Name updated Successfully";
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                return "Something went wrong! Please try again";
            }
        }



        internal async static Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            IEnumerable<Recipe> recipes = Enumerable.Empty<Recipe>();
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync("api/recipes");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    recipes = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(json);
                    if (recipes.Count() > 0)
                    {
                        Trace.WriteLine($"Get All Recipes Successful!");

                    }
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                throw new Exception(ex.Message);
            }
            return recipes;
        }


        internal async static Task<Recipe> GetRecipeById(int recipeId)
        {
            Recipe recipe = new Recipe();
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync($"api/recipe/{recipeId}");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    recipe = JsonConvert.DeserializeObject<Recipe>(json);
                    Trace.WriteLine($"Get Recipe by ID is Successful!");
                }
                else
                {
                    Trace.WriteLine($"Get Recipe by ID is Failed!");

                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                throw new Exception(ex.Message);
            }
            return recipe;
        }


        internal async static Task<String> AddRecipe(RecipeCreation recipe)
        {
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.PostAsJsonAsync("api/recipe/", recipe);

                Trace.WriteLine($"Status From POST {response.StatusCode}");
                response.EnsureSuccessStatusCode();
                Trace.WriteLine($"Added resources at {response.Headers.Location}");
                json = await response.Content.ReadAsStringAsync();
                Trace.WriteLine($"Add Recipe Successful!");

                return "Recipe Added Successfully";

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                return "Something went wrong! Please try again";
            }
        }


        internal async static Task<String> UpdateRecipe(int recipeid, RecipeCreation recipe)
        {
            try
            {
                string json;
                HttpResponseMessage response;

                json = JsonConvert.SerializeObject(recipe);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PutAsync($"api/recipe/{recipeid}", content);

                Trace.WriteLine($"Status From PUT {response.StatusCode}");
                response.EnsureSuccessStatusCode();

                Trace.WriteLine($"Updated Recipe!");
                json = await response.Content.ReadAsStringAsync();
                return "Recipe Updated Successfully";

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                return "Something went wrong! Please try again";
            }
        }



        internal async static Task<String> DeleteRecipe(int recipeId)
        {
            try
            {
                HttpResponseMessage response;
                response = await client.DeleteAsync($"api/recipe/{recipeId}");

                Trace.WriteLine($"Status From DELETE {response.StatusCode}");
                response.EnsureSuccessStatusCode();
                Trace.WriteLine($"Deleted Recipe!");
                return "Recipe Deleted Successfully";

            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                return "Something went wrong! Please try again";
            }
        }

        internal async static Task<String> PatchRecipe(int recipeId, int ingredientId, string measurement)
        {
            try
            {
                var patchDoc = new JsonPatchDocument<Recipeingredient>();
                patchDoc.Replace(i => i.measurement, measurement);
                var serializedDoc = JsonConvert.SerializeObject(patchDoc);
                var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");
                Trace.WriteLine($"Request Content {requestContent.ReadAsStringAsync().Result}");
                var uri = Path.Combine("api", "recipe", recipeId.ToString(), ingredientId.ToString());
                var response = await client.PatchAsync(uri, requestContent);

                response.EnsureSuccessStatusCode();
                Trace.WriteLine($"Patch Successful for Recipe!");
                return "Recipe Measurement updated Successfully";
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Failed to run {ex.Message}");
                return "Something went wrong! Please try again";
            }
        }


    }
}
