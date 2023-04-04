using AutoMapper;
using CookBookLibrary.Models;
using CookBookWebAPI.DTOs;
using CookBookWebAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private ICookBookRepository cookBookRepository;
        private readonly IMapper mapper;

        //Constructor
        public IngredientController(ICookBookRepository cookBookRepository, IMapper mapper)
        {
            this.cookBookRepository = cookBookRepository;
            this.mapper = mapper;
        }

        // GET: api/<IngredientController>
        //Get all Ingredients
        [HttpGet]
        [Route("/api/ingredients/")]
        public IActionResult GetAllIngredient()
        {
            var ingredients = cookBookRepository.GetIngredients();
            var results = mapper.Map<IEnumerable<IngredientDto>>(ingredients);
            return Ok(results);
        }

        // GET: api/<IngredientController>
        //Get Ingredient by ID
        [HttpGet("{ingredientId}")]
        public async Task<ActionResult<Ingredient>> GetIngredientById(int ingredientId)
        {
            var ingredient = await cookBookRepository.GetIngredientById(ingredientId);
            if (ingredient == null)
            {
                return NotFound();
            }
            var results = mapper.Map<IngredientDto>(ingredient);
            return Ok(results);
        }


        // POST api/<IngredientController>  
        //Add ingredient
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] IngredientCreationDto newIngredient)
        {
            if (newIngredient == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) { 
            return BadRequest(); }

            var ingredient = mapper.Map<Ingredient>(newIngredient);
            await cookBookRepository.AddIngredient(ingredient);
            var viewIngredient = mapper.Map<IngredientDto>(ingredient);
            return Created("Ingredient Added!", viewIngredient);
        }

        // PUT api/<IngredientController>  
        //update ingredient
        [HttpPut("{ingredientId}")]
        public async Task<IActionResult> PUT(int ingredientId, [FromBody] IngredientCreationDto updateIngredient)
        {
            if (updateIngredient == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await cookBookRepository.IngredientExistsAsync(ingredientId))
            {
                return NotFound();
            }
            var oldIngredient = cookBookRepository.GetIngredientById(ingredientId);
            if (oldIngredient.Result == null)
            {
                return NotFound();
            }
            mapper.Map(updateIngredient, oldIngredient.Result);
            if (!await cookBookRepository.SaveAsync())
            {
                return StatusCode(500, "A problem happened while handling your request");

            }
            return NoContent();
        }

        // DELETE api/<IngredientController>  
        //delete ingredient
        [HttpDelete("{ingredientId}")]
        public async Task<ActionResult> DeleteIngredient(int ingredientId)
        {
            if (!await cookBookRepository.IngredientExistsAsync(ingredientId))
            {
                return NotFound();
            }
            Ingredient ingredientToDelete = cookBookRepository.GetIngredientById(ingredientId).Result;
            if (ingredientToDelete == null)
            {
                return NotFound();
            }

            cookBookRepository.DeleteIngredient(ingredientToDelete);
            if (!await cookBookRepository.SaveAsync())
            {
                return StatusCode(500, "Deletion Failed!This Ingredient is used in Recipe(s)!");

            }
            return NoContent();

        }

        // PATCH api/<IngredientController>  
        //Paritally update Ingredient
        [HttpPatch("{ingredientId}")]
        public async Task<ActionResult> ParitiallyUpdateIngredient(int ingredientId, JsonPatchDocument<IngredientCreationDto> patchDocument)
        {
            if (!await cookBookRepository.IngredientExistsAsync(ingredientId))
            {
                return NotFound();
            }
            Ingredient ingredient = cookBookRepository.GetIngredientById(ingredientId).Result;
            if (ingredient == null)
            {
                return NotFound();
            }

            var recipeIngredientPatch = mapper.Map<IngredientCreationDto>(ingredient);
            patchDocument.ApplyTo(recipeIngredientPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(recipeIngredientPatch))
            {
                return BadRequest(ModelState);
            }
            mapper.Map(recipeIngredientPatch, ingredient);
            await cookBookRepository.SaveAsync();
            return NoContent();

        }
    }
}
