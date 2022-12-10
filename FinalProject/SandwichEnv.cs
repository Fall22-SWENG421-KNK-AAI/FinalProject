using FinalProject;

public class SandwichEnv : SandwichEnvIF
{
    private JobState state;
    private SandwichMachineIF machine;
    private AbstractSandwich sandwich;

    public SandwichEnv(SandwichMachineIF machine)
    {
        this.machine = machine;
        changeTo(new Idle());
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
        sandwich.setBread(bread);
    }

    public void placeCheese(Cheese type, int slices)
    {
        // To allow notifying customer step is complete.
		Topping top = (Topping)type;
		for (int i = 0; i < slices; i++)
		{
			top.addTopping();
            sandwich.addCheese(type);
		}
    }
    public void placeProtein(Protein type, int pieces)
    {
        for (int i = 0; i < pieces; i++)
        {
            type.addProtein();
            sandwich.addProtein(type);
        }
    }
    public void addToppings(Topping[] t)
    {
		foreach (Topping top in t)
		{
            top.addTopping();
			sandwich.addTopping(top);
		}
    }

    public void beginPlacingIngredients()
    {
        changeTo(state.processEvent(2));
        // perform all actions for sandwich setup
        Console.WriteLine("Placing Ingredients..."); 
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
        Console.WriteLine($"Toasting sandwich ${sec}");
        // Wrap next
        changeTo(state.processEvent(4));
    }   
    public void wrapSandwich() 
    {
		// Go to order complete
		changeTo(state.processEvent(5));
    }
    public JobState getJobState()
    {
        return state;
    }
}