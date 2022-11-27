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
            //write out Sandwich Shop Display
            Console.WriteLine("Welcome to the Sandwich Shop!");
            Console.WriteLine("What kind of Sandwhich would you like?");

            //create a new sandwich
            AbstractSandwich sandwich = new AbstractSandwich();           
            SandwichEnvIF env = new SandwichEnv();            
            sandwich.setEnvironment(env);
            
            sandwich.start();

            //wait for user input
            Console.ReadLine();
            
            
        }
    }
}
