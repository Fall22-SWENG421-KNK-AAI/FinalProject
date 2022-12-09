public abstract class Topping
{
	protected string name;
	protected int amount;
	protected double price;

	public void addTopping()
	{
		Console.WriteLine($"{name} added");
	}

	public void removeTopping()
	{
		Console.WriteLine($"{name} removed");
	}
}