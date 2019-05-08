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


        [BindProperty]
        public Recipe Recipe { get; set; }
        

        public void OnGet()
        {
            int.TryParse((string)RouteData.Values["Id"], out int id);
            Recipe = recipeRepository.GetRecipe(id);
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
    }
}