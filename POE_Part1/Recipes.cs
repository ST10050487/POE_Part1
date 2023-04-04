using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace POE_Part1
{
    internal class Recipes
    {
        // Declaring Variables to store user input
        String nameOfRecipe = "";
        String nameOfIngredient = "";
        String measurement = "";
        String description = "";

        int numOfIngredients = 0;
        double quantity = 0;
        int numOfSteps = 0;

        //***********************************************************NAKA****************************************************//
        // A method to get the Recipe name from user
        public String getNameOfRecipe()
        {
            Console.WriteLine("Enter The Name Of The Recipe >>");
            this.nameOfRecipe = Console.ReadLine();

            if ((string.IsNullOrEmpty(this.nameOfRecipe)) || (string.IsNullOrWhiteSpace(this.nameOfRecipe)))
            {
                Console.WriteLine("Please Enter Recipe Name Before Continuing");
                getNameOfRecipe();
            }
            return nameOfRecipe;
        }
        //***********************************************************NAKA****************************************************//
        // A method to get the number of Ingredients
        public void getNumberOfIngredients()
        {
            Console.WriteLine("Enter the Number Of Ingredients >>");
            while (int.TryParse(Console.ReadLine(), out numOfIngredients) == false)
            {
                Console.WriteLine("Please Enter the Number of Ingredients Before Continuing");
            }
            //numOfIngredients = Convert.ToInt32(placeHolder);
        }

        //***********************************************************NAKA****************************************************//
        // A method to get the Name of the Ingredient
        public String getNameOfIngredients()
        {
            Console.WriteLine("Enter the Name of the Ingredient >> ");
            this.nameOfIngredient = Console.ReadLine();
            if ((string.IsNullOrEmpty(this.nameOfIngredient)) || (string.IsNullOrWhiteSpace(this.nameOfIngredient)))
            {
                Console.WriteLine("Please Enter the Name of the Ingredient before Continuing");
                getNameOfIngredients();
            }
            return this.nameOfIngredient;
        }
        //***********************************************************NAKA****************************************************//
        // A method to get the Quantity of the Ingredient from User
        public double getQuantity()
        {
            Console.WriteLine("Enter the Quantity of the Ingredient >> ");
            while (double.TryParse(Console.ReadLine(), out quantity) == false)
            {
                Console.WriteLine("Please Enter the Quantity of the Ingredient before Continuing (as a number)");
            }
            return quantity;
        }
        //***********************************************************NAKA****************************************************//
        // A method to get the Unit of Measurement for the Ingredient from User
        public String getUnitOfMeasurement()
        {
            Console.WriteLine("Enter the Unit of Measurement  >> ");
            this.measurement = Console.ReadLine();
            if ((String.IsNullOrEmpty(measurement)) || (String.IsNullOrWhiteSpace(measurement)))
            {
                Console.WriteLine("Please Enter the Unit of Measurement for the Ingredient Before Continuing");
                getUnitOfMeasurement();
            }
            return measurement;
        }
        //***********************************************************NAKA****************************************************//
        // A method to get the number of Steps
        public int getNumberOfSteps()
        {
            Console.WriteLine("Enter the Number of Steps");
            while (int.TryParse(Console.ReadLine(), out numOfSteps) == false)
            {
                Console.WriteLine("Please Enter Number (Digit) of Steps Before Continuing");
            }
            return numOfSteps;
        }

        //***********************************************************NAKA****************************************************//
        // A metod to get the Description about what to do at every step
        public String getDescription()
        {
            Console.WriteLine("Enter Description on What to do on Step >> ");
            this.description = Console.ReadLine();
            if ((string.IsNullOrEmpty(description)) || (string.IsNullOrWhiteSpace(description)))
            {
                Console.WriteLine("Please Enter Step Description Before Continuing");
                getDescription();
            }
            return description;
        }

    }
}
