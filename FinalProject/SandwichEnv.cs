/**
 * This class represents an environment which is used to create sandwiches.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using FinalProject;
using Serilog;

public class SandwichEnv : SandwichEnvIF
{
    private JobState state;
    private SandwichMachineIF machine;
    private AbstractSandwich sandwich;
    int milliSecInSec = 1000;

    public SandwichEnv(SandwichMachineIF machine)
    {
        this.machine = machine;
        changeTo(new Idle());
    }

    public void setSandwich(AbstractSandwich sandwich)
    {
        this.sandwich = sandwich;
    }

	// help gotten from refactoring.guru/design-patterns/state/csharp/example
	public void changeTo(JobState state)
    {
        this.state = state;
        this.state.setContext(this);
    }

    // Following methods build the Sandwich created.
    public void placeBread(Bread bread)
    {
		changeTo(state.processEvent(2));
        
		bread.addBread();
		Thread.Sleep(milliSecInSec * 3);
		sandwich.setBread(bread);
    }

    public void placeCheese(Cheese type, int slices)
    {
		for (int i = 0; i < slices; i++)
		{
			type.addCheese();
            Thread.Sleep(milliSecInSec * 1);
            sandwich.addCheese(type);
		}
    }
    public void placeProtein(Protein type, int pieces)
    {
        for (int i = 0; i < pieces; i++)
        {
            type.addProtein();
			Thread.Sleep(milliSecInSec * 1);
			sandwich.addProtein(type);
        }
    }
    public void addToppings(Topping[] t)
    {
		foreach (Topping top in t)
		{
            top.addTopping();
			Thread.Sleep(milliSecInSec / 2);
			sandwich.addTopping(top);
		}
    }

    public void beginPlacingIngredients()
    {
        changeTo(state.processEvent(2));
        // perform all actions for sandwich setup
        Log.Information("Placing Ingredients..."); 
    }

    public void endPlacingIngredients()
    {
		// Go to next state based on sandwich
		if (sandwich.getNeedsToasting()) // Toast next.
		{
			changeTo(state.processEvent(3));
		}
		else // don't toast. move straight to wrapping
		{
			changeTo(state.processEvent(4));
		}
	}

    public void toastSandwich(int sec)
    {
        // Wrap next
		Log.Information("Toasting sandwich for {sec} seconds.", sec);
		Thread.Sleep(milliSecInSec * sec);
		changeTo(state.processEvent(4));
	}   
    public void wrapSandwich() 
    {
		// Go to order complete
		Thread.Sleep(milliSecInSec * 4);
		Log.Information("Wrapping sandwich...");
		changeTo(state.processEvent(5));
	}
    public JobState getJobState()
    {
        return state;
    }
}