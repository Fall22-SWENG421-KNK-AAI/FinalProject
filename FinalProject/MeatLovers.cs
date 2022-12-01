using FinalProject;

class MeatLovers : AbstractSandwich
{

    protected int totalRuntime;

    //constructor
    public MeatLovers()
    {

        //set the name
        string name = "Meat Lovers";
        //set the price
        double price = 6.99;
        //set the description
        string description = "A delicious sandwich with roastbeef, turkey, veggie patty, and cheese.";
    }
    public override void start() { }
}

