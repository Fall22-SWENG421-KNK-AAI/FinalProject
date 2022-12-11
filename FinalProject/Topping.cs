/**
 * This abstract class acts as the supreclass to the Tomato, Lettuce, Pickle, 
 * HotPepper, Mayonnaise, and Sriracha classes.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
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

	public string getName()
	{
		return name;
	}
}