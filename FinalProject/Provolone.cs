class Provolone : Topping, Cheese
{
    private string name;
    private double price;

    public Provolone()
    {
        name = "Provolone";
        price = 0.99;
    }

    public void addCheese()
    {
        Console.WriteLine("Provolone added");
    }

    public void removeCheese()
    {
        Console.WriteLine("Provolone removed");
    }

}
