using System.Text.RegularExpressions;
namespace FinalProject
{
	public class UI
	{
		string[] displayList;
		int numInput;
		string[] sandwichList;
		string input;

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
			Console.WriteLine("What kind of Sandwhich would you like?");
			for (int i = 0; i <= sandwichList.Length; i++)
			{
				Console.WriteLine(i + 1 + " " + displayList[i]);
			}
			Console.WriteLine("Select a number: ");

			while (true)
			{
				try
				{
					input = Console.ReadLine();
					numInput = Convert.ToInt32(input) - 1;
					if (numInput > displayList.Length - 1 || numInput < 1)
					{
						Console.WriteLine("Invalid input! Please try again.");
						continue;
					}
					return (Choice)numInput;
				}
				catch
				{
					Console.WriteLine("Invalid input! Please try again.");
					continue;
				}
			}
		}

		public bool AddMoreToOrder()
		{
			while (true)
			{
				Console.WriteLine($"Would you like to add more sandwiches to your order?");
				input = Console.ReadLine();

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
	}
}
