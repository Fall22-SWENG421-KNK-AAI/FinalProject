﻿/**
 * This class represents the user interface of the sandwich machine.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using System.Text.RegularExpressions;
namespace FinalProject
{
	public class UI
	{
		private string[] displayList;
		private string[] sandwichList;
		private string input;
		private int numInput;

        public UI()
		{
			input = "Y";
			numInput = 0;
			createLists();
		}

		private void createLists()
		{
			// Help gotten from https://stackoverflow.com/questions/130898/introduction-to-c-sharp-list-comprehensions
			IEnumerable<string> choices = from string sandwich in Enum.GetNames(typeof(Choice)) select sandwich;
			sandwichList = choices.ToArray();

			string sandwichNames = @"(?<firstWord>[A-Z][a-z]*)(?<secondWord>[A-Z][a-z]*)";
			string repl = "${firstWord} ${secondWord}";
			IEnumerable<string> forDisplay = from string name in sandwichList select Regex.Replace(name, sandwichNames, repl);
			displayList = forDisplay.ToArray();
		}

		public Choice DisplayMenu()
		{
            Console.WriteLine("\nWhat kind of Sandwhich would you like?");
			for (int i = 0; i < sandwichList.Length; i++)
			{
				Console.WriteLine(i + 1 + " " + displayList[i]);
			}
			Console.WriteLine("Select a number: ");

			while (true)
			{
				try
				{
					input = Console.ReadLine();
					numInput = Convert.ToInt32(input);
					if (numInput > displayList.Length || numInput < 1)
					{
						Console.WriteLine("Invalid input! Please try another number.");
						continue;
					}
					break;
				}
				catch
				{
					Console.WriteLine("Invalid input! Please enter the correct input.");
					continue;
				}
			}
			numInput--;
            return (Choice)numInput;
        }

		public bool AddMoreToOrder()
		{
			while (true)
			{
				Console.WriteLine($"Would you like to add more sandwiches to your order? (Y|N)");
				input = Console.ReadLine().ToUpper();

				switch (input)
				{
					case "Y":
						return true;
					case "N":
						return false;
					default:
						Console.WriteLine("Invalid answer! Please try again. (Y|N)");
						break;
				}
			}
		}

		public int AskActionToTake()
		{
            Console.WriteLine("\nWould you like to\n\t1) make an order or\n\t2) check your sandwich status?\nPlease select a number:");
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    numInput = Convert.ToInt32(input);
                    if (numInput > 2 || numInput < 1)
                    {
                        Console.WriteLine("Invalid input! Please try another number.");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input! Please enter the correct input.");
                    continue;
                }
            }
			return numInput;
        }

		public OrderStatus getOrderStatus(SandwichMachineIF machine)
		{
			OrderStatus stat;

            Console.WriteLine("\nEnter your order number (Enter b to exit):");
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
					numInput = Convert.ToInt32(input);
					stat = machine.getOrderStatus(numInput);

                    if (stat.Equals(OrderStatus.Invalid_Order))
					{
                        Console.WriteLine($"{stat} Please try a different order number.");
                        continue;
                    }
                    return stat;
                }
                catch
                {
                    if (input.Equals("b"))
					{
						return OrderStatus.Invalid_Order;
					}
					Console.WriteLine("Invalid input! Please enter the correct input.");
                    continue;
                }
            }
        }

		public bool PromptPickup()
		{
			Console.WriteLine("Would you like to pickup your order now? (Y|N)");
			while (true)
			{
				input = Console.ReadLine().ToUpper();

				switch (input)
				{
					case "Y":
						return true;
					case "N":
						return false;
					default:
						Console.WriteLine("Invalid answer! Please try again. (Y|N)");
						break;
				}
			}
		}

		public Order PickupOrder(bool b, SandwichMachineIF machine)
		{
            Order o = machine.PickupOrder(numInput);
            return o;
		}
		
		public void PrintReceipt(Order o)
		{
			double total = 0.0;
			foreach (AbstractSandwich s in o.getSandwiches())
			{
				Console.WriteLine(s);
				total += s.getPrice();
			}
			Console.WriteLine($"\tTotal Price: ${total}\n");
		}
    }
}
