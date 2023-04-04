using AutoMapper;
using CookBookLibrary.Models;
using CookBookWebAPI.DTOs;

namespace CookBookWebAPI.Mappings
{
    public class MappingsProfile : Profile
    {
       public MappingsProfile() {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeDto, Recipe>();
            CreateMap<Recipe,RecipeCreationDto>();

            CreateMap<RecipeCreationDto, Recipe>();
            CreateMap<RecipeCreationDto, RecipeDto>();
            CreateMap<RecipeIngredientPatchDto, RecipeIngredient>();
            CreateMap<RecipeIngredient, RecipeIngredientPatchDto>();

            CreateMap<RecipeIngredientCreationDto, RecipeIngredient>();
            CreateMap<RecipeIngredient, RecipeIngredientCreationDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto, Ingredient>();
            CreateMap<IngredientCreationDto, Ingredient>();
            CreateMap<Ingredient, IngredientCreationDto>();
            CreateMap<RecipeIngredient, RecipeIngredientDto>();
            CreateMap<RecipeIngredientDto, RecipeIngredient>();


        }
    }
}
