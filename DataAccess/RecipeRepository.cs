using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class RecipeRepository : CommonRepository
    {

        public List<Recipe> GetAllRecipesWithIngredients()
        {
            IngredientRepository ingredientRepository = new IngredientRepository();
            List<Recipe> recipes = GetAllRecipes();
            List<Ingredient> ingredients = ingredientRepository.GetAllIngredientsFull();

            //Match ingredients to recipes
            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    if (ingredient.RecipeId == recipe.Id)
                    {
                        recipe.Ingredients.Add(ingredient);
                    }
                }
                // Remove Ingredients already in a recipe
                ingredients = ingredients.Where(x => x.RecipeId == recipe.Id).ToList();
            }

            return recipes;
        }


        public List<Recipe> GetAllRecipes()
        {
            DataTable table = ExecuteQuery("exec dbo.GetAllRecipes");
            List<Recipe> recipes = new List<Recipe>();

            foreach (DataRow row in table.Rows)
            {
                recipes.Add(new Recipe()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Description = (string)row["Description"],
                    Ingredients = new List<Ingredient>()
                });
            }
            return recipes;
        }

        public Recipe GetRecipe(int id)
        {
            DataRow row = ExecuteQuery($"exec dbo.GetRecipe {id}").Rows[0];

            return new Recipe()
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                Description = (string)row["Description"]
            };
        }

        public int NewRecipe(Recipe recipe)
        {
            return ExecuteNonQueryScalar($"exec dbo.NewRecipe '{recipe.Name}', '{recipe.Description}'");
        } 

        public int UpdateRecipe(Recipe recipe)
        {
            return ExecuteNonQuery($"exec dbo.UpdateRecipe {recipe.Id}, '{recipe.Name}', '{recipe.Description}'");
        }

        public int DeleteRecipe(int id)
        {
            return ExecuteNonQuery($"exec dbo.DeleteRecipe {id}");
        }
    }
}
