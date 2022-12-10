using Serilog;
public abstract class Topping
{
	protected string name;
	protected double price;

	public void addTopping()
	{
		Log.Information("{name} added", name);
	}

	public void removeTopping()
	{
		Log.Information("{name} removed", name);
	}

	public double getPrice()
	{
		return price;
	}
}