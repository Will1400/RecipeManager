using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Ingredients
{
    public class CreateModel : PageModel
    {
        IngredientRepository ingredientRepository = new IngredientRepository();

        [BindProperty]
        public Ingredient Ingredient { get; set; }

        public void OnGet() {}

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ingredientRepository.NewIngredient(Ingredient);
                return Redirect("/Ingredients/Index");
            }
            return Page();
        }
    }
}