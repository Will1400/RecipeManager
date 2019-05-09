using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class IngredientsInRecipeRepository : CommonRepository
    {
        RecipeRepository recipeRepository = new RecipeRepository();
        public int AddNewIngredientsInRecipe(int recipeId, List<Ingredient> ingredients)
        {
            DataTable table = new DataTable();
            table.Columns.Add("IngredientId", typeof(int));
            table.Columns.Add("RecipeId", typeof(int));
            table.Columns.Add("Amount", typeof(int));
            table.Columns.Add("Unit", typeof(string));

            ingredients.ForEach(x => table.Rows.Add(x.Id, x.RecipeId, x.Amount, x.Unit));

            BulkInsert(table, "IngredientsInRecipe");

            return ingredients.Count;
        }

        public int RemoveIngredientFromRecipe(int recipeId, int ingredientId)
        {
            return ExecuteNonQuery($"exec dbo.RemoveIngredientFromRecipe {recipeId}, {ingredientId}");
        }

        public int UpdateIngredient(List<Ingredient> ingredients)
        {
            if (ingredients.Count < 1)
                return 0;

            int rowsAffected = 0;

            // Remove all ingredients without updates
            List<Ingredient> existingIngredients = recipeRepository.GetRecipe(ingredients[0].RecipeId).Ingredients;
            existingIngredients.ForEach(x => ingredients.RemoveAll(i => i.Equals(x)));

            foreach (Ingredient ingredient in ingredients)
            {
                 rowsAffected += ExecuteNonQuery($"exec dbo.UpdateIngredientInRecipe  {ingredient.Id}, {ingredient.RecipeId}, {ingredient.Amount}, '{(int)ingredient.Unit}'");
            }
            return rowsAffected;
        }
    }
}
