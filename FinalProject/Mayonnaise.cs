class Mayonnaise : Sauce, Topping
{
    //constructor
    public Mayonnaise()
    {
        //set the name
        string name = "Mayonnaise";
        //set the price
        double price = 0.99;
    }

    public void addSauce()
    {
        Console.WriteLine("Mayonnaise added");
    }
    public void removeSauce()
    {
        Console.WriteLine("Mayonnaise removed");
    }

}
