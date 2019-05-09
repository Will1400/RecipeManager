using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Ingredient
    {
        private int id;
        private int recipeId;
        private string name;
        private int amount;
        private IngredientType type;
        private Unit unit;


        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        [Required, EnumDataType(typeof(IngredientType), ErrorMessage = "Unit must be chosen")]
        public IngredientType Type
        {
            get { return type; }
            set { type = value; }
        }
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be above 0")]
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        [MinLength(2, ErrorMessage = "Name must be atleast 2 characters"), Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int RecipeId
        {
            get { return recipeId; }
            set { recipeId = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool IsVegetarian
        {
            get
            {
                if (type != IngredientType.Beef ||
                    type != IngredientType.Pork ||
                    type != IngredientType.Dairy)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
