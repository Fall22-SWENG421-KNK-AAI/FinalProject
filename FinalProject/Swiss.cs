class Swiss : Topping, Cheese
{
    private string name;
    private double price;

    public Swiss()
    {
        name = "Swiss";
        price = 0.99;
    }

    public void addCheese()
    {
        Console.WriteLine("Swiss added");
    }

    public void removeCheese()
    {
        Console.WriteLine("Swiss removed");
    }

}
