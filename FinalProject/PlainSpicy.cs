
//VeggieDelight class
using FinalProject;

class PlainSpicy : AbstractSandwich
{
    //constructor
    public PlainSpicy()
    {

        //set the name
        this.name = "Plain Spicy";
        //set the price
        this.price = 5.99;
        //set the description
        this.description = "A delicious sandwich with turkey, sriracha, hot peeper, and cheese.";
        this.totalRuntime = 5 * secsInMin;
        this.needsToasting = true;
    }
    public override void start() { }
}

