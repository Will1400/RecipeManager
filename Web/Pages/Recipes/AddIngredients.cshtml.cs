using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Recipes
{
    public class AddIngredientsModel : PageModel
    {
        IngredientRepository ingredientRepository = new IngredientRepository();
        RecipeRepository recipeRepository = new RecipeRepository();
        IngredientsInRecipeRepository ingredientsInRecipeRepository = new IngredientsInRecipeRepository();

        public Recipe Recipe { get; set; }

        [BindProperty]
        public List<Ingredient> Ingredients { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchType { get; set; }

        public void OnGet()
        {
            int.TryParse((string)RouteData.Values["Id"], out int id);
            Recipe = recipeRepository.GetRecipe(id);


            Ingredients = ingredientRepository.GetAllIngredients();

            // Remove ingredients already in the recipe
            Recipe.Ingredients.ForEach(x => Ingredients.RemoveAll(i => i.Id == x.Id));


            // Search Filtering
            if (!string.IsNullOrEmpty(SearchName) || !string.IsNullOrEmpty(SearchType))
            {
                if (!string.IsNullOrEmpty(SearchName))
                {
                    SearchName.Trim();
                    Ingredients.RemoveAll(i => !i.Name.ToLower().Contains(SearchName.ToLower()));
                }
                if (!string.IsNullOrEmpty(SearchType) && SearchType.ToLower() != "all")
                {
                    int.TryParse(SearchType, out int typeId);
                    IngredientType type = (IngredientType)typeId;
                    Ingredients.RemoveAll(i => i.Type != type);
                }
            }
        }


        public IActionResult OnPost(List<Ingredient> ingredients)
        {
            if (ModelState.IsValid)
            {
                int.TryParse((string)RouteData.Values["Id"], out int id);
                List<string> ids = Request.Form["IngredientId"].ToList();

                // Remove all non checked ingredients
                Ingredients.RemoveAll(x => !ids.Contains(x.Id.ToString()));

                ingredientsInRecipeRepository.AddNewIngredientsInRecipe(id, Ingredients);

                return RedirectToPage("/Recipes/Edit", new { Id = id });
            }
            OnGet();
            return Page();
        }
    }
}