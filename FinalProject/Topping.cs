public abstract class Topping
{
	protected string name;
	protected double price;

	public string addTopping()
	{
		return $"{name} added";
	}

	public string removeTopping()
	{
		return $"{name} removed";
	}
}