
using FinalProject;

class ForVegans : AbstractSandwich
{
    //constructor
    public ForVegans()
    {

        //set the name
        this.name = "For Vegans";
        //set the price
        this.price = 5.99;
        //set the description
        this.description = "A delicious sandwich with lettuce, tomato, pickle.";
        this.totalRuntime = 4 * secsInMin;
        this.needsToasting = false;
    }
    public override void start() { }

}

