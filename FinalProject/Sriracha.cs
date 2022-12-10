class Sriracha : Topping, Sauce
{
    
    public Sriracha()
    {        
        string name = "Sriracha";        
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
