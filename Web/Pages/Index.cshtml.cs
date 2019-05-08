using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using DataAccess;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        RecipeRepository recipeRepository = new RecipeRepository();

        public List<Recipe> Recipes { get; set; }

        public void OnGet()
        {
            Recipes = recipeRepository.GetAllRecipes();
        }
    }
}
