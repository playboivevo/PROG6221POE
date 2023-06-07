using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partOne
{
    internal class RecipeBook
    {
        
        public List<Recipe> Recipes { get; set; }

        public RecipeBook()
        {
            Recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }

        public void DisplayRecipeList()
        {
            var sortedRecipes = Recipes.OrderBy(recipe => recipe.Name);
            Console.WriteLine("Recipe List:");
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        public Recipe GetRecipeByName(string name)
        {
            return Recipes.FirstOrDefault(recipe => string.Equals(recipe.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }

}
