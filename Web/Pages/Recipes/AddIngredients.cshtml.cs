using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using DataAccess;

namespace Web.Pages.Recipes
{
    public class AddIngredientsModel : PageModel
    {
        IngredientRepository ingredientRepository = new IngredientRepository();
        RecipeRepository recipeRepository = new RecipeRepository();
        IngredientsInRecipeRepository ingredientsInRecipeRepository = new IngredientsInRecipeRepository();

        [BindProperty]
        public List<Ingredient> Ingredients { get; set; }


        public Recipe Recipe { get; set; }

        public void OnGet()
        {
            int.TryParse((string)RouteData.Values["Id"], out int id);
            Recipe = recipeRepository.GetRecipe(id);

            Ingredients = ingredientRepository.GetAllIngredients();

            foreach (var item in Recipe.Ingredients)
            {
                Ingredients.Remove(Ingredients.First(x => x.Id == item.Id));
            }
        }

        public IActionResult OnPost(List<Ingredient> ingredients)
        {
            int.TryParse((string)RouteData.Values["Id"], out int id);
            List<string> ids = Request.Form["IngredientId"].ToList();

            foreach (Ingredient item in ingredients)
            {
                if (!ids.Contains(item.Id.ToString()))
                    Ingredients.Remove(item);
            }

            ingredientsInRecipeRepository.AddNewIngredientsInRecipe(id, Ingredients);

            return RedirectToPage("/Recipes/Edit", new { Id = id });
        }
    }
}