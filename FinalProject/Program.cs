using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Program
    {
		public static int millisecInSec = 1000;
		public static int secInMin = 60;
		public static int waitTimeMin = 5;
		public static int waitTime = waitTimeMin * secInMin * millisecInSec;
		static StreamWriter w = new StreamWriter("application-log.txt"); //File.AppendText("application-log.txt");

		public static void Main(string[] args)
        {
			int customerCount = 1;
			UI ui = new UI();
			Order order = new Order();
			SandwichMachineIF machine = new SandwichMachine();
			Choice sandwichChoice;
			Log("Test1", w);
			Log("Test2", w);
			w.Close();

			Console.WriteLine("Welcome to the Sandwich Shop!");

			while (true)
			{
				Console.WriteLine("May we take your order, Customer #" + customerCount + "?");
				sandwichChoice = ui.DisplayMenu();
				order = machine.AddSandwichToOrder(sandwichChoice.ToString(), order);

				while (ui.AddMoreToOrder())
				{
					sandwichChoice = ui.DisplayMenu();
					order = machine.AddSandwichToOrder(sandwichChoice.ToString(), order);
				}

				machine.PlaceOrder(order);
				customerCount++;
			}
        }

		public static void Log(string logMessage, TextWriter w)
		{
			Console.WriteLine("Test Message");
			w.Write("\r\nLog Entry : ");
			w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
			w.WriteLine("  :");
			w.WriteLine($"  :{logMessage}");
			w.WriteLine ("-------------------------------");
		}

		// Help gotten from https://dotnettutorials.net/lesson/retry-pattern-in-csharp/
		public static async void tryProcessOrder(SandwichMachineIF machine)
		{
			while(true) // Run constantly
			{
				try
				{
					// This causes to run in background
					await Task.Run(() => {
						machine.PickOrder();
					});
					//break;
				}
				catch (SandwichMachine.MachineException e)
				{
					await Task.Delay(waitTime);
				}
			}
		}
	}
}
