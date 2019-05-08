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
    public class IndexModel : PageModel
    {
        IngredientRepository ingredientRepository = new IngredientRepository();
        
        public List<Ingredient> Ingredients { get; set; }

        public void OnGet()
        {
            Ingredients = ingredientRepository.GetAllIngredients();
        }
    }
}