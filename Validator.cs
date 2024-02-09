using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighschoolDBv8
{
    internal class Validator
    {
        public static int GetValidInt(string message)
        {
            int choice;
            while (true)
            {
                Console.Write("\n\t" + message + ": ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\n\tInvalid input. Please enter an integer.");
                }
                else
                {
                    break;
                }
            }
            return choice;
        }
        public static string GetValidString(string message)
        {
            string choice = String.Empty;
            while (String.IsNullOrEmpty(choice))
            {
                Console.Write("\n\t" + message + ": ");
                choice = Console.ReadLine();
                if (String.IsNullOrEmpty(choice))
                    Console.WriteLine("\n\ttry again");
            }
            return choice;
        }
    }
}
