class Sriracha : Topping, Sauce
{
    //constructor
    public Sriracha()
    {
        //set the name
        string name = "Sriracha";
        //set the price
        double price = 0.99;
    }

    public void addSauce()
    {
        Console.WriteLine("Sriracha added");
    }
    public void removeSauce()
    {
        Console.WriteLine("Sriracha removed");
    }

}
