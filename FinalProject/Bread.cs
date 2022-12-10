using Serilog;
public abstract class Bread
{
    protected string name;
    protected double price;

    public void addBread()
    {
        Log.Information("{name} Bread added", name);
    }
    public double getPrice()
    {
        return price;
    }
}