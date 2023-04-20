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
            //Creating an object of the Recipes class
            GetUserInput gt = new GetUserInput();

            // Calling the excuteChoice() method
            ric.excuteChoice();

            Console.ReadKey();
        }

    }
}
