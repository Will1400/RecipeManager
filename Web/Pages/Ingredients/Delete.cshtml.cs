using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Ingredients
{
    public class DeleteModel : PageModel
    {
        IngredientRepository ingredientRepository = new IngredientRepository();

        [BindProperty]
        public Ingredient Ingredient { get; set; }
        public void OnGet()
        {
            int.TryParse((string)RouteData.Values["Id"], out int id);
            Ingredient = ingredientRepository.GetIngredient(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ingredientRepository.DeleteIngredient(Ingredient.Id);
                return Redirect("/Ingredients/Index");
            }
            return Page();
        }
    }
}