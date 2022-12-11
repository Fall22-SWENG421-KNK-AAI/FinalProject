/**
 * This abstract class acts as the superclass to the White and Wheat classes.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using Serilog;
public abstract class Bread
{
    protected string name;

    public void addBread()
    {
        Log.Information("{name} Bread added", name);
    }

    public string getName()
    {
        return name;
    }
}