using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Web.Pages.Recipes
{
    public class EditModel : PageModel
    {
        RecipeRepository recipeRepository = new RecipeRepository();
        IngredientRepository ingredientRepository = new IngredientRepository();
        IngredientsInRecipeRepository ingredientsInRecipeRepository = new IngredientsInRecipeRepository();


        [BindProperty]
        public Recipe Recipe { get; set; }


        [BindProperty]
        public List<Ingredient> Ingredients { get; set; } /*Used to update ingredients*/

        public void OnGet()
        {
            int.TryParse((string)RouteData.Values["Id"], out int id);
            Recipe = recipeRepository.GetRecipe(id);
            Ingredients = Recipe.Ingredients;
        }

        public IActionResult OnGetRemoveIngredient(int ingredientId)
        {
            int.TryParse((string)RouteData.Values["Id"], out int id);

            ingredientsInRecipeRepository.RemoveIngredientFromRecipe(id, ingredientId);

            return RedirectToPage("/Recipes/Edit", new { Id = id });
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                recipeRepository.UpdateRecipe(Recipe);
                return Redirect("/Recipes/Index");
            }
            return Page();
        }

        public IActionResult OnPostUpdateIngredients(List<Ingredient> ingredients)
        {
            if (ModelState.IsValid)
            {
                ingredientsInRecipeRepository.UpdateIngredient(ingredients);
                return Redirect("/Recipes/Index");
            }
            return Page();
        }
    }
}