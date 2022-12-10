using FinalProject;

public class SandwichEnv : SandwichEnvIF
{
    private JobState state;
    private SandwichMachineIF machine;
    private AbstractSandwich sandwich; // how to get current sandwich into variable?

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
        sandwich.setBread(bread);
    }

    public void placeCheese(Cheese type, int slices)
    {
		for (int i = 0; i < slices; i++)
		{
			type.addCheese();
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

    public string beginPlacingIngredients()
    {
        changeTo(state.processEvent(2));
        // perform all actions for sandwich setup
        return "Placing Ingredients..."; 
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

    public string toastSandwich(int sec)
    {
        // Wrap next
        changeTo(state.processEvent(4));
        return $"Toasting sandwich {sec}";
    }   
    public string wrapSandwich() 
    {
		// Go to order complete
		changeTo(state.processEvent(5));
        return "Wrapping sandwich...";
    }
    public JobState getJobState()
    {
        return state;
    }
}