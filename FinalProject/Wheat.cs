public class Wheat : Bread
{
    private string name;
    private double price;

    public Wheat()
    {
        name = "Wheat";
        price = 0.99;
    }

    public void addBread()
    {
        Console.WriteLine("Wheat Bread added");
    }
    
}
