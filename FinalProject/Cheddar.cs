public class Cheddar : Topping, Cheese
{
    public Cheddar()
    {
        name = "Cheddar Cheese";
        price = 0.99;
    }
    public void addCheese()
    {
        Console.WriteLine("Cheddar added");
    }

    public void removeCheese()
    {
        Console.WriteLine("Cheddar removed");
    }
}
