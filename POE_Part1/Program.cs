using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Part1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Creating an object of the Recipes class
            Recipes ric = new Recipes();

            // Calling the getNameOfRecipe() method
            ric.getNameOfRecipe();
            // Calling the getNumberOfIngredients() method
            ric.getNumberOfIngredients();
            // Calling the getNameOfIngredients();
            ric.getNameOfIngredients();
            // Calling the getQuantity() method
            ric.getQuantity();
            // Calling the getUnitOfMeasurement() method
            ric.getUnitOfMeasurement();
            // Calling the getNumberOfSteps() method
            ric.getNumberOfSteps();
            // Calling the getDescription() method
            ric.getDescription();

            Console.ReadKey();
        }
    }
}
