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
        public string FilterType { get; set; } = "all";

        public void OnGet()
        {
            FilterType = FilterType.ToLower();

            if (FilterType != "all")
            {
                Recipes = recipeRepository.GetAllRecipesWithIngredients();
                if (FilterType == "nonvegan")
                {
                    Recipes.RemoveAll(x => x.IsVegetarian);
                }
                else if (FilterType == "vegan")
                {
                    Recipes.RemoveAll(x => !x.IsVegetarian);
                }
                return;
            }
            Recipes = recipeRepository.GetAllRecipes();
        }
    }
}
