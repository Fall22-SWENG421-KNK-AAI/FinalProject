using FinalProject;

class TheClassic : AbstractSandwich
{
    //constructor
    public TheClassic()
    {

        //set the name
        this.name = "The Classic";
        //set the price
        this.price = 5.99;
        //set the description
        this.description = "A delicious sandwich with roastbeef, turkey, and cheese.";
        this.totalRuntime = 6 * secsInMin;
        this.needsToasting = true;
    }
    public override void start() { }
}

