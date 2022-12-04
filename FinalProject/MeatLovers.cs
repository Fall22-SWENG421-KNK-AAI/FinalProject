using FinalProject;

class MeatLovers : AbstractSandwich
{

    protected int totalRuntime;

    //constructor
    public MeatLovers()
    {
        //set the name
        this.name = "Meat Lovers";
        //set the price
        this.price = 6.99;
        //set the description
        this.description = "A delicious sandwich with roastbeef, turkey, veggie patty, and cheese.";
        this.totalRuntime = 8 * secsInMin;
        this.needsToasting = true;
    }
    public override void start() { }
}

