using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        RecipeRepository recipeRepository = new RecipeRepository();

        public List<Recipe> Recipes { get; set; }

        public void OnGet()
        {
            Recipes = recipeRepository.GetAllRecipes();
        }
        public IActionResult OnGetDelete()
        {
            int.TryParse((string)RouteData.Values["Id"], out int id);
            recipeRepository.DeleteRecipe(id);
            return Redirect("/Recipes/Index");
        }
    }
}