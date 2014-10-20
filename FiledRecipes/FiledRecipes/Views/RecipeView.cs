using FiledRecipes.Domain;
using FiledRecipes.App.Mvp;
using FiledRecipes.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiledRecipes.Views
{
    /// <summary>
    /// 
    /// </summary>
    public class RecipeView : ViewBase, IRecipeView
    {

        public void Show(IRecipe recipe, bool clear = true)
        {
            if (clear)
            {
                Console.Clear();
            }

            Header = recipe.Name;
            ShowHeaderPanel();

            Console.WriteLine(Strings.Ingredients);

            for (int i = 0; i < Strings.Ingredients.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            foreach (IIngredient ing in recipe.Ingredients)
            {
                Console.WriteLine(ing.ToString());
            }

            Console.WriteLine();

            Console.WriteLine(Strings.Instructions);
            for (int i = 0; i < Strings.Instructions.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            int j = 1;

            foreach (string ins in recipe.Instructions)
            {
                Console.WriteLine("<{0}>", j++);
                Console.WriteLine(ins.ToString());

            }
		}



        public void Show(IEnumerable<IRecipe> recipes)
        {
            foreach (IRecipe recipe in recipes)
            {
                Show(recipe);
                ContinueOnKeyPressed();
                Console.Clear();
            }

        }
    }
}
