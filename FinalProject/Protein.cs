/**
 * This abstract class acts as the superclass to the Turkey, RoastBeef,
 * VeggiePatty, and NoProtein classes.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using Serilog;
public abstract class Protein
{    
    protected string name;
    protected double price;

    public virtual void addProtein()
    {
        Log.Information("{name} added", name);
    }

    public virtual void removeProtein()
    {
        Log.Information("{name} removed", name);
    }

    public double getPrice()
    {
        return price;
    }
}
