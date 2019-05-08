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
    public class CreateModel : PageModel
    {
        RecipeRepository recipeRepository = new RecipeRepository();

        [BindProperty]
        public Recipe Recipe { get; set; }

        public void OnGet() {}

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                recipeRepository.NewRecipe(Recipe);
                return Redirect("/Recipes/Index");
            }
            return Page();
        }
    }
}