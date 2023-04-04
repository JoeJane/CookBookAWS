using AutoMapper;
using CookBookLibrary.Models;
using CookBookWebAPI.DTOs;
using CookBookWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private ICookBookRepository cookBookRepository;
        private readonly IMapper mapper;

        public RecipeController(ICookBookRepository cookBookRepository, IMapper mapper)
        {
            this.cookBookRepository = cookBookRepository;
            this.mapper = mapper;
        }


        // GET: api/<RecipeController>
        //Get all recipes
        [HttpGet]
        [Route("/api/recipes/")]
        public IActionResult GetAllRecipes()
        {
            var recipes = cookBookRepository.GetRecipes();

            var results = mapper.Map<IEnumerable<RecipeDto>>(recipes);

            return Ok(results);
        }

        // GET: api/<RecipeController>
        [HttpGet("{recipeId}")]
        public IActionResult GetRecipeById(int recipeId)
        {
            var recipes = cookBookRepository.GetRecipeById(recipeId);

            var results = mapper.Map<RecipeDto>(recipes.Result);

            return Ok(results);
        }

        // GET: api/<RecipeController>
        //Get all recipes for a given cuisne
        [HttpGet]
        [Route("/api/recipes/cuisine")]
        public IActionResult GetRecipesByCuisine(String cuisine)
        {
            var recipes = cookBookRepository.GetRecipeByCuisine(cuisine);

            var results = mapper.Map<IEnumerable<RecipeDto>>(recipes);

            return Ok(results);
        }

        // POST api/<RecipeController>  
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RecipeCreationDto newRecipe)
        {
            if (newRecipe == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            var recipe = mapper.Map<Recipe>(newRecipe);
            await cookBookRepository.AddRecipe(recipe);
            var viewRecipe = mapper.Map<RecipeDto>(recipe);
            return Created("URI of the created entity", viewRecipe);
        }


        [HttpPut("{recipeId}")]
        public async Task<IActionResult> PUT(int recipeId, [FromBody] RecipeCreationDto updateRecipe)
        {
            if (updateRecipe == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await cookBookRepository.RecipeExistsAsync(recipeId))
            {
                return NotFound();
            }
            var oldRecipe = cookBookRepository.GetRecipeById(recipeId);
            if (oldRecipe.Result == null)
            {
                return NotFound();
            }
            mapper.Map(updateRecipe, oldRecipe.Result);
            if (!await cookBookRepository.SaveAsync())
            {
                return StatusCode(500, "A problem happened while handling your request");

            }
            return NoContent();
        }

        [HttpDelete("{recipeId}")]
        public async Task<ActionResult> DeleteRecipe(int recipeId)
        {
            if (!await cookBookRepository.RecipeExistsAsync(recipeId))
            {
                return NotFound();
            }
            Recipe recipeToDelete = cookBookRepository.GetRecipeById(recipeId).Result;
            if (recipeToDelete == null)
            {
                return NotFound();
            }

            cookBookRepository.DeleteRecipe(recipeToDelete);
            if (!await cookBookRepository.SaveAsync())
            {
                return StatusCode(500, "A problem happened while handling your request");

            }
            return NoContent();

        }

        [HttpPatch("{recipeId}/{ingredientId}")]
        public async Task<ActionResult> ParitiallyUpdateRecipeMeasurement(int recipeId,int ingredientId,JsonPatchDocument<RecipeIngredientPatchDto> patchDocument)
        {
            if (!await cookBookRepository.RecipeExistsAsync(recipeId))
            {
                return NotFound();
            }
            RecipeIngredient recipeIngredient =  cookBookRepository.GetRecipeIngredientById(recipeId,ingredientId).Result;
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            var recipeIngredientPatch = mapper.Map<RecipeIngredientPatchDto>(recipeIngredient);
            patchDocument.ApplyTo(recipeIngredientPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(recipeIngredientPatch))
            {
                return BadRequest(ModelState);
            }
            mapper.Map(recipeIngredientPatch, recipeIngredient);
            await cookBookRepository.SaveAsync();
            return NoContent();

        }

      
    }
}
