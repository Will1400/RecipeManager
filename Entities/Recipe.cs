using System;
using System.Collections.Generic;
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
    }
}
