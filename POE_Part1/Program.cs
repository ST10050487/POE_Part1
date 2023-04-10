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

            //Calling the welcomeMessage() method
            ric.welcomeMessage();
            //A calling the getChoice() method
            ric.getChoice();
            // Calling the excuteChoice() method
            ric.excuteChoice();

            Console.ReadKey();
        }

    }
}
