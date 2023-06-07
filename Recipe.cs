using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partOne
{
    internal class Recipe
    {

         
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = Math.Round(ingredient.OriginalQuantity * factor, 2);
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }

        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }

        public bool ExceedsCalorieLimit()
        {
            return CalculateTotalCalories() > 300;
        }
    }

}
