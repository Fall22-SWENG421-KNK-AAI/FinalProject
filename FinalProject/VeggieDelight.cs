
using FinalProject;

class VeggieDelight : AbstractSandwich
{

    protected int totalRuntime;
    
    //constructor
    public VeggieDelight()
    {
        
        //set the name
        string name = "Veggie Delight";
        //set the price
        double price = 5.99;
        //set the description
        string description = "A delicious sandwich with lettuce, tomato, pickle, and cheese.";
    }


    public void setEnvironment(SandwichEnvIF c) { }
    public override void start() { }

}

