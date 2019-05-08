﻿using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class IngredientsInRecipeRepository : CommonRepository
    {
        public int AddNewIngredientsInRecipe(int recipeId, List<Ingredient> ingredients)
        {
            int rowsAffected = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                rowsAffected += ExecuteNonQuery($"exec dbo.AddNewIngredientToRecipe {ingredient.Id}, {recipeId}, {ingredient.Amount}, '{ingredient.Unit}'");
            }
            return rowsAffected;
        }

        public int RemoveIngredientFromRecipe(int recipeId, int ingredientId)
        {
            return ExecuteNonQuery($"exec dbo.RemoveIngredientFromRecipe {recipeId}, {ingredientId}");
        }
    }
}