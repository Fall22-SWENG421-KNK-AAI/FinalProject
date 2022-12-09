using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sandwichList = {"", "VeggieDelight", "MeatLovers", "TheClassic", "PlainSpicy", "forVegans"};
            string[] displayList = { "", "Veggie", "Meat", "Classic", "Spicy", "Vegan" };
            string input = "1";
            int numInput = 1;
            //write out Sandwich Shop Display
            Console.WriteLine("Welcome to the Sandwich Shop!");
            Console.WriteLine("What kind of Sandwhich would you like? Select a number:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i + " " + displayList[i]);
            }

            //wait for user input
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    numInput = Convert.ToInt32(input);
                    if (numInput > displayList.Length - 1 && numInput < 1)
                    {
                        Console.WriteLine("Invalid input! Please try again.");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input! Please try again.");
                    continue;
                }
                break;
            }

            Console.WriteLine("You selected: " + displayList[numInput]);

            //create a new sandwich
            AbstractSandwich sandwich;
            SandwichEnvIF env = new SandwichEnv();
            SandwichCreatorIF sif = new SandwichCreator();
            sandwich = sif.createSandwich(sandwichList[numInput]);
            sandwich.setEnvironment(env);

        }
    }
}
