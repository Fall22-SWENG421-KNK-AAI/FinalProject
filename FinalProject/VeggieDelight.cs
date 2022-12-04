
using FinalProject;

public class VeggieDelight : AbstractSandwich
{

    protected int totalRuntime;
    
    //constructor
    public VeggieDelight()
    {
        
        //set the name
        this.name = "Veggie Delight";
        //set the price
        this.price = 5.99;
        //set the description
        this.description = "A delicious sandwich with lettuce, tomato, pickle, and cheese.";
        this.totalRuntime = 5 * secsInMin;
		this.needsToasting = false;
	}

    public override void start()
    {
        
    }

}

