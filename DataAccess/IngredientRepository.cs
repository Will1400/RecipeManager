using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class IngredientRepository : CommonRepository
    {
        public List<Ingredient> GetAllIngredients()
        {
            DataTable table = ExecuteQuery("exec dbo.GetAllIngredients");
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (DataRow row in table.Rows)
            {
                ingredients.Add(new Ingredient()
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Type = (IngredientType)(int)row["Type"]
                });
            }
            return ingredients;
        }

        public List<Ingredient> GetAllIngredientsFull()
        {
            DataTable table = ExecuteQuery("exec dbo.GetAllIngredientsFull");
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (DataRow row in table.Rows)
            {
                Enum.TryParse((string)row["Unit"], out Unit unit); // Convert string to unit
                ingredients.Add(new Ingredient()
                {
                    Id = (int)row["Id"],
                    RecipeId = (int)row["recipeid"],
                    Name = (string)row["Name"],
                    Type = (IngredientType)(int)row["Type"],
                    Amount = (int)row["Amount"],
                    Unit = unit
                });
            }

            return ingredients;
        }

        public Ingredient GetIngredient(int id)
        {
            DataRow row = ExecuteQuery($"exec dbo.GetIngredient {id}").Rows[0];

            return new Ingredient()
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                Type = (IngredientType)(int)row["Type"]
            };
        }

        public int DeleteIngredient(int id)
        {
            return ExecuteNonQuery($"exec dbo.DeleteIngredient {id}");
        }

        public int NewIngredient(Ingredient ingredient)
        {
            return ExecuteNonQuery($"exec dbo.NewIngredient '{ingredient.Name}', {(int)ingredient.Type}");
        }

        public int UpdateIngredient(Ingredient ingredient)
        {
            return ExecuteNonQuery($"exec dbo.UpdateIngredient {ingredient.Id}, '{ingredient.Name}', {(int)ingredient.Type}");
        }

    }
}
