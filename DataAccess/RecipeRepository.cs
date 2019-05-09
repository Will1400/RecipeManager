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
                //ingredients = ingredients.Where(x => x.RecipeId == recipe.Id).ToList();
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
            DataRow recipeRow = ExecuteQuery($"exec dbo.GetRecipe {id}").Rows[0];
            Recipe recipe = new Recipe()
            {
                Id = (int)recipeRow["Id"],
                Name = (string)recipeRow["Name"],
                Description = (string)recipeRow["Description"],
                Ingredients = new List<Ingredient>()
            };

            // Placed after creation of recipe for easier id access
            DataTable ingredientsTable = ExecuteQuery($"exec dbo.GetIngredientsInRecipe {recipe.Id}");

            foreach (DataRow row in ingredientsTable.Rows)
            {
                Enum.TryParse((string)row["Unit"], out Unit unit); // Convert string to unit
                recipe.Ingredients.Add(new Ingredient()
                {
                    Id = (int)row["Id"],
                    RecipeId = (int)row["RecipeId"],
                    Name = (string)row["Name"],
                    Type = (IngredientType)(int)row["Type"],
                    Unit = unit,
                    Amount = (int)row["Amount"]
                });
            }

            return recipe;
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
