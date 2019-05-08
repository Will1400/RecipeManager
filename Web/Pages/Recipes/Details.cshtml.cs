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
    public class DetailsModel : PageModel
    {
        RecipeRepository recipeRepository = new RecipeRepository();

        public Recipe Recipe { get; set; }

        public void OnGet()
        {
            int.TryParse((string)RouteData.Values["Id"], out int id);
            Recipe = recipeRepository.GetRecipe(id);
        }
    }
}