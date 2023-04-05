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
        int keepCount = 1;
        int keepCount2 = 1;
        int numOfSteps = 0;
        int choice;

        //Declaring Arrays to store user input
        String[] Ingredients;
        double[] Quantity;
        String[] Measurement;
        String[] Steps;

        //***********************************************************NAKA****************************************************//
        // A method to Print the Welcome Message
        public void welcomeMessage()
        {
            Console.WriteLine("\n Welcome to PerfectionRecipes\n /*********************************/");
            Console.WriteLine();
            Console.WriteLine("Menu\n********************************* \n Please Select the Following Options: \n 1. Enter Recipe \n " +
                "2. Display Reciep \n 3. Half Quantity \n 4. Double Quantity \n 5. Triple Quantity \n" +
                "6. Restore Quantity to Default \n 7. QUIT");
        }
        //***********************************************************NAKA****************************************************//
        // A method to get the selection from user
        public void getChoice()
        {
            while (int.TryParse(Console.ReadLine(), out choice) == false)
            {
                Console.WriteLine("Enter the choice as an Integer");
                Console.WriteLine();
                Console.WriteLine("Menu \n Please Select the Following Options (Enter Number): \n 1. Enter Recipe \n " +
                    "2. Display Reciep \n 3. Half Quantity \n 4. Double Quantity \n 5. Triple Quantity \n" +
                    " 6. Restore Quantity to Default \n 7. QUIT");
            }
        }
        //***********************************************************NAKA****************************************************//
        // A method to excute the selected option by user
        public void excuteChoice()
        {
            switch (choice)
            {
                case 1:
                    getNameOfRecipe();
                    getNumberOfIngredients();
                    getIngredientsInfo();
                    getNumberOfSteps();
                    getAllSteps();
                    displayRecipe();
                    returnToMenu();
                    Console.ReadKey();
                    welcomeMessage();
                    getChoice();
                    excuteChoice();
                    break;
                case 2:
                    displayRecipe();
                    returnToMenu();
                    Console.ReadKey();
                    welcomeMessage();
                    getChoice();
                    excuteChoice();
                    break;
                case 7:
                    Console.WriteLine("Thank you for using PerfectionRecipes");
                    break;
                default:
                    if ((choice <= 0) || (choice > 7))
                    {
                        Console.WriteLine("Please enter a number provided on the menu");
                        getChoice();
                        excuteChoice();
                    }
                    break;
            }
        }
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
        // A method to get Ingredient Infor from user
        public void getIngredientsInfo()
        {
            Ingredients = new string[numOfIngredients];
            Quantity = new double[numOfIngredients];
            Measurement = new string[numOfIngredients];

            for (int cnt = 0; cnt < this.numOfIngredients; cnt++)
            {
                Ingredients[cnt] = getNameOfIngredients();
                Quantity[cnt] = getQuantity();
                Measurement[cnt] = getUnitOfMeasurement();
                keepCount++;
            }
        }
        //***********************************************************NAKA****************************************************//
        // A method to get the Name of the Ingredient
        public String getNameOfIngredients()
        {
            Console.WriteLine("Enter the Name of the Ingredient " + keepCount + " >> ");
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
            Console.WriteLine("Enter the Quantity of the Ingredient " + keepCount + " >> ");
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
            Console.WriteLine("Enter the Unit of Measurement " + keepCount + " >> ");
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
        // A method to get all the Steps from User
        public void getAllSteps()
        {
            Steps = new string[numOfSteps];
            for (int cnt = 0; cnt < numOfSteps; cnt++)
            {
                Steps[cnt] = getDescription();
                keepCount2++;
            }
        }
        //***********************************************************NAKA****************************************************//
        // A metod to get the Description about what to do at every step
        public String getDescription()
        {
            Console.WriteLine("Enter Description on What to do on Step " + keepCount2 + " >> ");
            this.description = Console.ReadLine();
            if ((string.IsNullOrEmpty(description)) || (string.IsNullOrWhiteSpace(description)))
            {
                Console.WriteLine("Please Enter Step Description Before Continuing");
                getDescription();
            }
            return description;
        }
        //***********************************************************NAKA****************************************************//
        // A method to print all the elements in all the arrays
        public void print(String[] arra, double[] arr, String[] ar)
        {
            Console.WriteLine("Ingredient Name \t\tQuantity \t\t Measuremnts");
            for (int cnt = 0; cnt < arra.Length; cnt++)
            {
                Console.WriteLine();
                Console.WriteLine("{0} \t\t\t\t{1} \t\t\t{2}", arra[cnt], arr[cnt], ar[cnt]);
            }
        }
        //***********************************************************NAKA****************************************************//
        // A method to print all the elements in the Steps array
        public void printSteps(String[] instractions)
        {
            int keepTrack = 1;
            for (int cnt = 0; cnt < Steps.Length; cnt++)
            {
                Console.WriteLine("Step " + keepTrack + ": " + Steps[cnt]);
                keepTrack++;
            }
        }
        //***********************************************************NAKA****************************************************//
        // A method to print the Recipe
        public void displayRecipe()
        {
            Console.WriteLine("");
            Console.WriteLine("*************************************" + nameOfRecipe + "*************************************");
            Console.WriteLine("");
            print(Ingredients, Quantity, Measurement);
            Console.WriteLine("");
            printSteps(Steps);
        }
        //***********************************************************NAKA****************************************************//
        // A method to return to the Menu
        public void returnToMenu()
        {
            Console.WriteLine("\nThank you for using  PerfectionRecipes " +
                      "\n Press Any Key to Return to Menu");
        }

    }
}
