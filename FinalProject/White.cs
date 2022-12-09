public class White : Bread
{
    private string name;
    private double price;
    
    public White()
    {
        name = "White";
        price = 0.99;
    }

    public void addBread()
    {
        Console.WriteLine("White Bread added");
    }


}