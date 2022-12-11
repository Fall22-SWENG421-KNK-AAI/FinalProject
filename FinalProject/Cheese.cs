/**
 * This abstract class acts as the superclass to the American, Cheddar, Swiss,
 * Provolone, and NoCheese classes.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using Serilog;
public abstract class Cheese
{
    protected string name;
    protected double price;

    public virtual void addCheese()
    {
        Log.Information("{name} added", name);
    }

    public virtual void removeCheese()
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