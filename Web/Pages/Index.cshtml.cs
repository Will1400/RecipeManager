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

        [BindProperty(SupportsGet = true)]
        public int FilterType { get; set; } = -1;

        public void OnGet()
        {
            Recipes = recipeRepository.GetAllRecipes();

            if (FilterType != -1)
            {
                if (FilterType == 0)
                {
                    Recipes.RemoveAll(x => x.IsVegetarian);
                }
                else if (FilterType == 1)
                {
                    Recipes.RemoveAll(x => !x.IsVegetarian);
                }
            }
        }
    }
}
