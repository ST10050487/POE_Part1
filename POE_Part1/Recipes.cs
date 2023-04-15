using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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
        int keptCount = 1;
        int keptCount2 = 1;
        int numOfSteps = 0;
        int choice;

        // Declaring constatnts
        const double HALF = 0.5;
        const int DOUBLE = 2;
        const int TRIPLE = 3;

        //Declaring Arrays to store user input
        String[] Ingredients;
        double[] Quantity;
        String[] Measurement;
        String[] Steps;
        int[] KeepCount;
        int[] KeepCount2;

        //***********************************************************NAKA****************************************************//
        // A method to Print the Welcome Message
        public void welcomeMessage()
        {
            Console.WriteLine("\n Welcome to PerfectionRecipes\n /*********************************/");
            Console.WriteLine();
            Console.WriteLine("Menu\n********************************* \n Please Select the Following Options: \n 1. Enter Recipe \n " +
                "2. Display Reciep \n 3. Half Quantity \n 4. Double Quantity \n 5. Triple Quantity \n" +
                " 6. Restore Quantity to Default \n 7. Clear Recipe \n 8. QUIT");
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
                    " 6. Restore Quantity to Default \n 7.  Clear Recipe \n 8. QUIT");
            }
        }
        //***********************************************************NAKA****************************************************//
        // A method to excute the selected option by user
        public void excuteChoice()
        {
            // Intilazing the Arrays
            Ingredients = new string[numOfIngredients];

            switch (choice)
            {
                case 1:
                    getUserInput();
                    break;
                case 2:
                    if (Ingredients.Length == 0)
                    {
                        warningMessage();
                    }
                    else
                    {
                        printRecipe();
                    }
                    break;
                case 3:
                    if (Ingredients.Length == 0)
                    {
                        warningMessage();
                    }
                    else
                    {
                        HalfQuantity(Ingredients, Quantity, Measurement);
                    }
                    break;
                case 4:
                    if (Ingredients.Length == 0)
                    {
                        warningMessage();
                    }
                    else
                    {
                        DoubleQuantity(Ingredients, Quantity, Measurement);
                    }
                    break;
                case 5:
                    if (Ingredients.Length == 0)
                    {
                        warningMessage();
                    }
                    else
                    {
                        TripleQuantity(Ingredients, Quantity, Measurement);
                    }
                    break;
                case 6:
                    if (Ingredients.Length == 0)
                    {
                        warningMessage();
                    }
                    else
                    {
                        printRecipe();
                    }
                    break;
                case 7:
                    if (Ingredients.Length == 0)
                    {
                        warningMessage();
                    }
                    else
                    {
                        clearRecipe(Ingredients, Quantity, Measurement, Steps, KeepCount, KeepCount2);
                    }
                    break;
                case 8:
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
        }
        //***********************************************************NAKA****************************************************//
        // A method to get Ingredient Infor from user
        public void getIngredientsInfo()
        {
            // Setting the size of the Arrays
            Ingredients = new string[numOfIngredients];
            Quantity = new double[numOfIngredients];
            Measurement = new string[numOfIngredients];
            int[] KeepCount = new int[numOfIngredients];

            for (int cnt = 0; cnt < this.numOfIngredients; cnt++)
            {
                Ingredients[cnt] = getNameOfIngredients();
                Quantity[cnt] = getQuantity();
                Measurement[cnt] = getUnitOfMeasurement();
                KeepCount[cnt] = keptCount;
                keptCount++;
            }
        }
        //***********************************************************NAKA****************************************************//
        // A method to get the Name of the Ingredient
        public String getNameOfIngredients()
        {
            Console.WriteLine("Enter the Name of the Ingredient " + keptCount + " >> ");
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
            Console.WriteLine("Enter the Quantity of the Ingredient " + keptCount + " >> ");
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
            Console.WriteLine("Enter the Unit of Measurement " + keptCount + " >> ");
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
            int[] KeepCount2 = new int[numOfSteps];
            for (int cnt = 0; cnt < numOfSteps; cnt++)
            {
                Steps[cnt] = getDescription();
                KeepCount2[cnt] = keptCount2;
                keptCount2++;
            }
        }
        //***********************************************************NAKA****************************************************//
        // A metod to get the Description about what to do at every step
        public String getDescription()
        {
            Console.WriteLine("Enter Description on What to do on Step " + keptCount2 + " >> ");
            this.description = Console.ReadLine();
            if ((string.IsNullOrEmpty(description)) || (string.IsNullOrWhiteSpace(description)))
            {
                Console.WriteLine("Please Enter Step Description Before Continuing");
                getDescription();
            }
            return description;
        }
        //***********************************************************NAKA****************************************************//
        // A method that calls all the neccessary methods to capture the Recipe
        public void getUserInput()
        {
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
        // A method to call the neccessary methods to Display the array
        public void printRecipe()
        {
            displayRecipe();
            returnToMenu();
            Console.ReadKey();
            welcomeMessage();
            getChoice();
            excuteChoice();
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
        // A method to print the Halfed Quantity
        public void HalfQuantity(String[] Name, double[] ToHalf, String[] Measure)
        {
            Console.WriteLine("\n\nAfter The Recipe Has Been Halfed: \n");
            Console.WriteLine("*************************************" + nameOfRecipe + "*************************************\n");
            Console.WriteLine("Ingredient Name \t\tQuantity \t\t Measuremnts");
            for (int cnt = 0; cnt < Quantity.Length; cnt++)
            {
                Console.WriteLine("{0} \t\t\t\t{1} \t\t\t{2}", Name[cnt], (Quantity[cnt] * HALF), Measure[cnt]);
            }
            printSteps(Steps);
            returnToMenu();
            Console.ReadKey();
            welcomeMessage();
            getChoice();
            excuteChoice();
        }
        //***********************************************************NAKA****************************************************//
        // A method to print the Doubled Quantity
        public void DoubleQuantity(String[] Name, double[] ToDouble, String[] Measure)
        {
            Console.WriteLine("\n\nAfter The Recipe Has Been Doubled: \n");
            Console.WriteLine("*************************************" + nameOfRecipe + "*************************************\n");
            Console.WriteLine("Ingredient Name \t\tQuantity \t\t Measuremnts");
            for (int cnt = 0; cnt < Quantity.Length; cnt++)
            {
                Console.WriteLine("{0} \t\t\t\t{1} \t\t\t{2}", Name[cnt], (Quantity[cnt] * DOUBLE), Measure[cnt]);
            }
            printSteps(Steps);
            returnToMenu();
            Console.ReadKey();
            welcomeMessage();
            getChoice();
            excuteChoice();
        }
        //***********************************************************NAKA****************************************************//
        // A method to print the Tripled Quantity
        public void TripleQuantity(String[] Name, double[] ToTriple, String[] Measure)
        {
            Console.WriteLine("\n\nAfter The Recipe Has Been Tripled: \n");
            Console.WriteLine("*************************************" + nameOfRecipe + "*************************************\n");
            Console.WriteLine("Ingredient Name \t\tQuantity \t\t Measuremnts");
            for (int cnt = 0; cnt < Quantity.Length; cnt++)
            {
                Console.WriteLine("{0} \t\t\t\t{1} \t\t\t{2}", Name[cnt], (Quantity[cnt] * TRIPLE), Measure[cnt]);
            }
            printSteps(Steps);
            returnToMenu();
            Console.ReadKey();
            welcomeMessage();
            getChoice();
            excuteChoice();
        }
        //***********************************************************NAKA****************************************************//
        // A method to return to the Menu
        public void returnToMenu()
        {
            Console.WriteLine("\nThank you for using  PerfectionRecipes " +
                      "\n Press Any Key to Return to Menu");
        }
        //***********************************************************NAKA****************************************************//
        // A method to Clear the Recipe (Clearing the Array)
        public void clearRecipe(String[] arra, double[] arr, String[] ar, String[] Steps, int[] Keep1, int[] Keep2)
        {
            Array.Clear(arra, 0, arra.Length);
            Array.Clear(arr, 0, arr.Length);
            Array.Clear(ar, 0, ar.Length);
            Array.Clear(Steps,0, Steps.Length);
            //Array.Clear(Keep1,0,Keep1.Length);
            //Array.Clear(Keep2, 0, Keep2.Length);
            Console.WriteLine("\n\nYour Recipe has been successfully Deleted\n");

            returnToMenu();
            Console.ReadKey();
            welcomeMessage();
            getChoice();
            excuteChoice();
        }
        //***********************************************************NAKA****************************************************//
        //A method to notify the user that the Array is empty
        public void warningMessage()
        {
            Console.WriteLine("Database is empty" +
                          "\nPlease enter Recipe first (select 1 in Menu)" +
                          "\nEnter any key to return to Menu");
            Console.ReadKey();
            welcomeMessage();
            getChoice();
            excuteChoice();
        }
        public long ConvertToNumbers(string numberString)
        {
            Dictionary<string, long> numbers = new Dictionary<string, long>{
        {"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},{"five",5},{"six",6},
        {"seven",7},{"eight",8},{"nine",9},{"ten",10},{"eleven",11},{"twelve",12},
        {"thirteen",13},{"fourteen",14},{"fifteen",15},{"sixteen",16},{"seventeen",17},
        {"eighteen",18},{"nineteen",19},{"twenty",20},{"thirty",30},{"forty",40},
        {"fifty",50},{"sixty",60},{"seventy",70},{"eighty",80},{"ninety",90},
        {"hundred",100},{"thousand",1000},{"million",1000000},{"billion",1000000000},
                {"trillion",1000000000000},{"quadrillion",1000000000000000},
        {"quintillion",1000000000000000000}
    };
            var num = Regex.Matches(numberString, @"\w+").Cast<Match>()
                .Select(m => m.Value.ToLowerInvariant())
                .Where(v => numbers.ContainsKey(v))
                .Select(v => numbers[v]);
            long acc = 0, total = 0L;
            foreach (var n in num)
            {
                if (n >= 1000)
                {
                    total += acc * n;
                    acc = 0;
                }
                else if (n >= 100)
                {
                    acc *= n;
                }
                else acc += n;
            }
            return (total + acc) * (numberString.StartsWith("minus",
                    StringComparison.InvariantCultureIgnoreCase) ? -1 : 1);
        }
        public void test()
        {
            Console.WriteLine("ENTER QUANTITY>>");
            try
            {
                string strNumber = Console.ReadLine();
                var rtnNumber = ConvertToNumbers(strNumber);

                Console.WriteLine("Number is {0}", rtnNumber);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Quantity in word form>>");
                test();
            }
        }

    }

}

