using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Recipe
    {
        private List<Ingredient> ingredients;
        private string description;
        private string name;
        private int id;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [MinLength(1), Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        public bool IsVegetarian
        {
            get
            {
                foreach (Ingredient item in ingredients)
                {
                    if (!item.IsVegetarian)
                        return false;
                }

                return true;
            }
        }
    }
}
