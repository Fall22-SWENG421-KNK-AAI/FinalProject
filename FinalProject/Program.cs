using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace FinalProject
{
    public class Program
    {
		public static int millisecInSec = 1000;
		public static int sec = 3;
		public static int waitTime = sec * millisecInSec;

		public static void Main(string[] args)
        {
			int customerCount = 1;
			OrderStatus orderStatus;
            UI ui = new UI();
			SandwichMachineIF machine = new SandwichMachine();
			Choice sandwichChoice;
			// Creates a logging object to be used in application
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.File("app-log.txt",
					outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
					rollingInterval: RollingInterval.Day)
				.CreateLogger();

			Console.WriteLine("Welcome to the Sandwich Shop!");

            tryProcessOrder(machine);
			while (true)
			{
				int action = ui.AskActionToTake();
                if (action == 1) // Take new Order
				{
                    Order order = new Order();

                    sandwichChoice = ui.DisplayMenu();
                    order = machine.AddSandwichToOrder(sandwichChoice.ToString(), order);

                    while (ui.AddMoreToOrder())
                    {
                        sandwichChoice = ui.DisplayMenu();
                        order = machine.AddSandwichToOrder(sandwichChoice.ToString(), order);
                    }
					Console.WriteLine($"Your order number is {order.getOrderNumber()}");
                    machine.PlaceOrder(order);
                    customerCount++;
                }
				else if (action == 2) // Check status of order
				{
					orderStatus = ui.getOrderStatus(machine);
					if (!orderStatus.Equals(OrderStatus.InvalidOrder)) // valid order
					{
						Console.WriteLine($"\n\tOrder Status: {orderStatus}");
						if (orderStatus.Equals(OrderStatus.Ready))
						{
							bool wantPickup = ui.PromptPickup();
							if (wantPickup)
							{
								Order readyOrder = ui.PickupOrder(wantPickup, machine);
								ui.PrintReceipt(readyOrder);
							}
						}
                    }
				}
			}
        }

		// Help gotten from https://dotnettutorials.net/lesson/retry-pattern-in-csharp/
		// and https://stackoverflow.com/questions/30462079/run-async-method-regularly-with-specified-interval
		public static async void tryProcessOrder(SandwichMachineIF machine, CancellationToken c = default)
		{
			// This causes to run in background
			while (true)
			{
				await Task.Run(() => {
					machine.PickOrder();
				});
				await Task.Delay(waitTime, c);
			}
		}
	}
}
