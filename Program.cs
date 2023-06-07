using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partOne
{
    internal class Program
    {
        static void Main()
        {
            var recipeBook = new RecipeBook();

            while (true)
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. Display Recipe List");
                Console.WriteLine("3. Display Recipe Details");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Recipe Quantities");
                Console.WriteLine("6. Exit");

                Console.Write("\nEnter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GatherRecipeDetails(recipeBook);
                        break;
                    case "2":
                        recipeBook.DisplayRecipeList();
                        break;
                    case "3":
                        DisplayRecipeDetails(recipeBook);
                        break;
                    case "4":
                        ScaleRecipe(recipeBook);
                        break;
                    case "5":
                        ResetRecipeQuantities(recipeBook);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void GatherRecipeDetails(RecipeBook recipeBook)
        {
            Console.Write("Enter the recipe name: ");
            var name = Console.ReadLine();
            var recipe = new Recipe(name);

            Console.Write("Enter the number of ingredients: ");
            var numIngredients = int.Parse(Console.ReadLine());

            for (var i = 0; i < numIngredients; i++)
            {
                Console.Write("Enter the ingredient name: ");
                var ingredientName = Console.ReadLine();

                Console.Write("Enter the unit of measurement: ");
                var unit = Console.ReadLine();

                Console.Write("Enter the quantity: ");
                var quantity = double.Parse(Console.ReadLine());

               

                Console.Write("Enter the number of calories: ");
                var calories = double.Parse(Console.ReadLine());

                Console.Write("Enter the food group: ");
                var foodGroup = Console.ReadLine();

                var ingredient = new Ingredient
                {
                    Name = ingredientName,
                    Quantity = quantity,
                    Unit = unit,
                    Calories = calories,
                    FoodGroup = foodGroup,
                    OriginalQuantity = quantity
                };

                recipe.AddIngredient(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            var numSteps = int.Parse(Console.ReadLine());

            for (var i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                var step = Console.ReadLine();
                recipe.AddStep(step);
            }

            recipeBook.AddRecipe(recipe);
            Console.WriteLine("Recipe added successfully.");
        }

        static void DisplayRecipeDetails(RecipeBook recipeBook)
        {
            recipeBook.DisplayRecipeList();

            Console.Write("Enter the recipe name: ");
            var recipeName = Console.ReadLine();

            var recipe = recipeBook.GetRecipeByName(recipeName);
            if (recipe != null)
            {
                Console.WriteLine("\nRecipe Details:");
                Console.WriteLine($"Name: {recipe.Name}");

                Console.WriteLine("\nIngredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
                }

                Console.WriteLine("\nSteps:");
                for (var i = 0; i < recipe.Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
                }

                Console.WriteLine("\nTotal Calories: " + recipe.CalculateTotalCalories());

                if (recipe.ExceedsCalorieLimit())
                {
                    Console.WriteLine("WARNING: This recipe exceeds 300 calories.");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        static void ScaleRecipe(RecipeBook recipeBook)
        {
            DisplayRecipeDetails(recipeBook);

            Console.Write("Enter the recipe name: ");
            var recipeName = Console.ReadLine();

            var recipe = recipeBook.GetRecipeByName(recipeName);
            if (recipe != null)
            {
                Console.Write("Enter the scaling factor: ");
                var factor = double.Parse(Console.ReadLine());

                recipe.ScaleRecipe(factor);
                Console.WriteLine("Recipe scaled successfully.");
                DisplayRecipeDetails(recipeBook);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        static void ResetRecipeQuantities(RecipeBook recipeBook)
        {
            DisplayRecipeDetails(recipeBook);

            Console.Write("Enter the recipe name: ");
            var recipeName = Console.ReadLine();

            var recipe = recipeBook.GetRecipeByName(recipeName);
            if (recipe != null)
            {
                recipe.ResetQuantities();
                Console.WriteLine("Recipe quantities reset successfully.");
                DisplayRecipeDetails(recipeBook);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
}
    
    