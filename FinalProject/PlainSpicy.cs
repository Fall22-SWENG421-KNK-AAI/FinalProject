
//VeggieDelight class
using FinalProject;

class PlainSpicy : AbstractSandwich
{

    protected int totalRuntime;

    //constructor
    public PlainSpicy()
    {

        //set the name
        string name = "Plain Spicy";
        //set the price
        double price = 5.99;
        //set the description
        string description = "A delicious sandwich with turkey, sriracha, hot peeper, and cheese.";
    }
    public override void start() { }
}

