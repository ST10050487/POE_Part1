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
        //Creating an object of the Recipes class
        GetUserInput grt = new GetUserInput();

        // Declaring constatnts
        const double HALF = 0.5;
        const int DOUBLE = 2;
        const int TRIPLE = 3;

        //Declaring variables
        String title = "";

        //***********************************************************NAKA****************************************************//
        // A method to excute the selected option by user
        public void excuteChoice()
        {
            int choice = grt.getChoice();
            switch (choice)
            {
                case 1:
                    title = grt.getNameOfRecipe();
                    grt.getRecipe();
                    displayRecipe();
                    returnToMenu();
                    excuteChoice();
                    break;
                case 2:
                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                    {
                        warningMessage();
                    }
                    else
                    {
                        displayRecipe();
                        excuteChoice();
                    }
                    break;
                case 3:
                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                    {
                        warningMessage();
                    }
                    else
                    {
                        HalfQuantity(grt.Ingredients, grt.Quantity, grt.Measurement);
                        excuteChoice();
                    }
                    break;
                case 4:
                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                    {
                        warningMessage();
                    }
                    else
                    {
                        DoubleQuantity(grt.Ingredients, grt.Quantity, grt.Measurement);
                        excuteChoice();
                    }
                    break;
                case 5:
                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                    {
                        warningMessage();
                    }
                    else
                    {
                        TripleQuantity(grt.Ingredients, grt.Quantity, grt.Measurement);
                        excuteChoice();
                    }
                    break;
                case 6:
                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                    {
                        warningMessage();
                    }
                    else
                    {
                        displayRecipe();
                        excuteChoice();
                    }
                    break;
                case 7:
                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title))
                    {
                        warningMessage();
                    }
                    else
                    {
                        clearRecipe(grt.Ingredients, grt.Quantity, grt.Measurement, grt.Steps, grt.KeepCount, grt.KeepCount2);
                        excuteChoice();
                    }
                    break;
                case 8:
                    Console.WriteLine("Thank you for using PerfectionRecipes");
                    break;
                default:
                    if ((choice <= 0) || (choice > 8))
                    {
                        Console.WriteLine("Please enter a number provided on the menu");
                        excuteChoice();
                    }
                    break;
            }
        }
        //***********************************************************NAKA****************************************************//
        // A method to print the complete Recipe 
        public void displayRecipe()
        {
            Console.WriteLine("##################################################################################");
            Console.WriteLine("");
            Console.WriteLine("*************************************<" + title.ToUpper() + ">*************************************");
            Console.WriteLine("");
            printIngredients();
            Console.WriteLine("\n\n");
            Console.WriteLine("*************************************<" + "STEPS" + ">*******************************************\n");
            printSteps(grt.Steps);
            Console.WriteLine();
            Console.WriteLine("##################################################################################");

            returnToMenu();
            excuteChoice();
        }
        //***********************************************************NAKA****************************************************//
        // A method to print all the Ingredients, Quantities and Measurements
        public void printIngredients()
        {
            Console.WriteLine("Ingredient Name \t\tQuantity \t\t Measuremnts");
            for (int cnt = 0; cnt < grt.Ingredients.Length; cnt++)
            {
                Console.WriteLine();
                Console.WriteLine("{0} \t\t\t\t{1} \t\t\t{2}", this.grt.Ingredients[cnt], this.grt.Quantity[cnt], this.grt.Measurement[cnt]);
            }
        }
        //***********************************************************NAKA****************************************************//
        // A method to print all the Steps of the Recipe
        public void printSteps(String[] Instractions)
        {
            int keepTrack = 1;
            for (int cnt = 0; cnt < grt.Steps.Length; cnt++)
            {
                Console.WriteLine("Step " + keepTrack + ": " + Instractions[cnt]);
                Console.WriteLine();
                keepTrack++;
            }
        }
        //***********************************************************NAKA****************************************************//
        // A method to print the Halfed Quantity
        public void HalfQuantity(String[] Name, double[] ToHalf, String[] Measure)
        {
            Console.WriteLine("\n\nAfter The Recipe Has Been Halfed: \n");
            Console.WriteLine("*************************************<" + title.ToUpper() + ">*************************************\n");
            Console.WriteLine("Ingredient Name \t\tQuantity \t\t Measuremnts");
            for (int cnt = 0; cnt < grt.Quantity.Length; cnt++)
            {
                Console.WriteLine("{0} \t\t\t\t{1} \t\t\t{2}", Name[cnt], (grt.Quantity[cnt] * HALF), Measure[cnt]);
                Console.WriteLine();
            }
            Console.WriteLine("*************************************<" + "STEPS" + ">*******************************************\n");
            printSteps(grt.Steps);
            Console.WriteLine();
            Console.WriteLine("##################################################################################");
            returnToMenu();
            excuteChoice();
        }
        //***********************************************************NAKA****************************************************//
        // A method to print the Doubled Quantity
        public void DoubleQuantity(String[] Name, double[] ToDouble, String[] Measure)
        {
            Console.WriteLine("\n\nAfter The Recipe Has Been Doubled: \n");
            Console.WriteLine("*************************************<" + title.ToUpper() + ">*************************************\n");
            Console.WriteLine("Ingredient Name \t\tQuantity \t\t Measuremnts");
            for (int cnt = 0; cnt < grt.Quantity.Length; cnt++)
            {
                Console.WriteLine("{0} \t\t\t\t{1} \t\t\t{2}", Name[cnt], (grt.Quantity[cnt] * DOUBLE), Measure[cnt]);
                Console.WriteLine();
            }
            Console.WriteLine("*************************************<" + "STEPS" + ">*******************************************\n");
            printSteps(grt.Steps);
            Console.WriteLine();
            Console.WriteLine("##################################################################################");
            returnToMenu();
            excuteChoice();
        }
        //***********************************************************NAKA****************************************************//
        // A method to print the Tripled Quantity
        public void TripleQuantity(String[] Name, double[] ToTriple, String[] Measure)
        {
            Console.WriteLine("\n\nAfter The Recipe Has Been Tripled: \n");
            Console.WriteLine("*************************************<" + title.ToUpper() + ">*************************************\n");
            Console.WriteLine("Ingredient Name \t\tQuantity \t\t Measuremnts");
            for (int cnt = 0; cnt < grt.Quantity.Length; cnt++)
            {
                Console.WriteLine("{0} \t\t\t\t{1} \t\t\t{2}", Name[cnt], (grt.Quantity[cnt] * TRIPLE), Measure[cnt]);
                Console.WriteLine();
            }
            Console.WriteLine("*************************************<" + "STEPS" + ">*******************************************\n");
            printSteps(grt.Steps);
            Console.WriteLine();
            Console.WriteLine("##################################################################################");
            returnToMenu();
            excuteChoice();
        }
        //***********************************************************NAKA****************************************************//
        // A method to return to the Menu
        public void returnToMenu()
        {
            Console.WriteLine("\nThank you for using  PerfectionRecipes " +
                      "\n Press Any Key to Return to Menu");
            Console.ReadKey();
        }
        //***********************************************************NAKA****************************************************//
        // A method to Clear the Recipe (Clearing the Array)
        public void clearRecipe(String[] arra, double[] arr, String[] ar, String[] Steps, int[] keep1, int[] keep2)
        {
            Array.Clear(arra, 0, arra.Length);
            Array.Clear(arr, 0, arr.Length);
            Array.Clear(ar, 0, ar.Length);
            Array.Clear(Steps, 0, Steps.Length);
            /*Checking if the Arrays (keep and Keepz) are empty first before clearing them.
            The program does not run without these conditional oparetors*/
            int[] keep = keep1 == null ? new int[0] : keep1;
            int[] keepz = keep2 == null ? new int[0] : keep2;
            Array.Clear(keep, 0, keep.Length);
            Array.Clear(keepz, 0, keepz.Length);
            Console.WriteLine("\n\nYour Recipe has been successfully Deleted\n");

            returnToMenu();
            Console.ReadKey();
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
            excuteChoice();
        }
    }

}

