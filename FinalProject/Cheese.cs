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
}