using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POE_Part1
{
    public class GetUserInput
    {
        // Declaring Variables to store user input (Strings)
        String nameOfRecipe = "";
        String nameOfIngredient = "";
        String measurement = "";
        String description = "";

        // Declaring Variables to store user input (intergers and doubles)
        int numOfIngredients = 0;
        double quantity = 0;
        int keptCount = 1;
        int keptCount2 = 1;
        int numOfSteps = 0;
        int choice;

        //Declaring Arrays to store user input
        public String[] Ingredients;
        public double[] Quantity;
        public String[] Measurement;
        public String[] Steps;
        public int[] KeepCount;
        public int[] KeepCount2;

        //***********************************************************NAKA****************************************************//
        // A method to get the selection from user
        public int getChoice()
        {
            int store = 0;
            Console.WriteLine("##################################################################################");
            Console.WriteLine("\nWelcome to PerfectionRecipes\n /*********************************/");
            Console.WriteLine();
            Console.WriteLine("Menu\n********************************* \n Please Select the Following Options: \n 1. Enter Recipe \n " +
                "2. Display Reciep \n 3. Half Quantity \n 4. Double Quantity \n 5. Triple Quantity \n" +
                " 6. Restore Quantity to Default \n 7. Clear Recipe \n 8. QUIT");
            Console.WriteLine("##################################################################################");

            string keep = Console.ReadLine();
            if (int.TryParse(keep, out store) == true)
            {
                choice = store;

            }
            else
            {
                choice = (int)ConvertToNumbers(keep);
            }
            if (choice == 0)
            {
                Console.WriteLine("Invalid Input Please Enter Valid Number between 1 & 8 (e.g. 1 O/R Eight )");
                getChoice();
            }
            return choice;
        }
        //***********************************************************NAKA****************************************************//
        //A method to call all the methods needed to capture the recipe
        public void getRecipe()
        {
            getNumberOfIngredients();
            getIngredientsInfo();
            getNumberOfSteps();
            getAllSteps();
        }
        //***********************************************************NAKA****************************************************//
        // A method to get the Recipe name from user
        public String getNameOfRecipe()
        {
            Console.WriteLine("Enter The Name Of The Recipe >>");
            String storeInput = Console.ReadLine();
            if ((string.IsNullOrEmpty(storeInput)) || (string.IsNullOrWhiteSpace(storeInput)))
            {
                Console.WriteLine("Please Enter Recipe Name Before Continuing");
                getNameOfRecipe();
            }
            nameOfRecipe = ValidateInput(storeInput);
            return nameOfRecipe;
        }

        //***********************************************************NAKA****************************************************//
        // A method to get the number of Ingredients
        public int getNumberOfIngredients()
        {
            int store;
            Console.WriteLine("Enter the Number Of Ingredients >>");
            string keep = Console.ReadLine();
            if (int.TryParse(keep, out store) == true)
            {
                numOfIngredients = store;
            }
            else
            {
                numOfIngredients = (int)ConvertToNumbers(keep);
            }
            if (numOfIngredients == 0)
            {
                Console.WriteLine("Invalid Input Please Enter Valid Number (e.g. 1 O/R six ) that is not Zero(0)");
                getNumberOfIngredients();
            }

            return numOfIngredients;
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
            double store;
            Console.WriteLine("Enter the Quantity of the Ingredient " + keptCount + " >> ");
            string keep = Console.ReadLine();
            if (double.TryParse(keep, out store) == true)
            {
                quantity = store;
            }
            else
            {
                quantity = ConvertToNumbers(keep);
            }
            if (quantity == 0)
            {
                Console.WriteLine("Invalid Input Please Enter Valid Number (e.g. 1 O/R one )");
                getQuantity();
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
            int store;
            Console.WriteLine("Enter the Number of Steps");
            String keep = Console.ReadLine();
            if (int.TryParse(keep, out store) == true)
            {
                numOfSteps = store;
            }
            else
            {
                numOfSteps = (int)ConvertToNumbers(keep);
            }
            if (numOfSteps == 0)
            {
                Console.WriteLine("Invalid Input Please Enter Valid Number as follows (e.g. 1 O/R one )");
                getNumberOfSteps();
            }
            return numOfSteps;
        }
        //***********************************************************NAKA****************************************************//
        // A method to get all the Steps from User
        public void getAllSteps()
        {
            int[] KeepCount2 = new int[numOfSteps];
            Steps = new String[numOfSteps];
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
        // A method to varify if user input is a string or not
        public String ValidateInput(String word)
        {
            double number;
            while (double.TryParse(word, out number) == true)
            {
                Console.WriteLine("Invalid input Please Enter a Word (e.g.'BANANA BREAD') not a Nmuber>> ");
                word = Console.ReadLine();
                while ((string.IsNullOrEmpty(word)) || (string.IsNullOrWhiteSpace(word)))
                {
                    Console.WriteLine("Please Enter Recipe Name Before Continuing>>");
                    word = Console.ReadLine();
                }
            }
            return word;
        }
        //***********************************************************NAKA****************************************************//
        // A method to covert numbers in words to numeric values
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
    }
}
