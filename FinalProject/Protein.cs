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
