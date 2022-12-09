using FinalProject;

public class SandwichEnv : SandwichEnvIF
{
    private JobState state;
    private SandwichCreatorIF creator;
    private AbstractSandwich sandwich;
    private Order sandwichOrder;

    public SandwichEnv(string sandwich)
    {
        creator = new SandwichCreator();
        // Uses Factory method to create empty template sandwich type
        this.sandwichOrder = creator.createSandwich(sandwich);
        changeToState(new Idle());
    }

	// help gotten from refactoring.guru/design-patterns/state/csharp/example
	public void changeToState(JobState state)
    {
        this.state = state;
        this.state.setContext(this);
    }

    // Following methods build the Sandwich created.
    public void placeBread(Bread bread)
    {
		changeToState(state.processEvent(2));
        
		bread.addBread();
		sandwich.setBread(bread);
    }

    public void placeCheese(Cheese type, int slices)
    {
        // To allow notifying customer step is complete.
		Topping top = (Topping)type;
        lock (sandwich)
        {
			for (int i = 0; i < slices; i++)
			{
				top.addTopping();
				sandwich.addCheese(type);
			}
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
    public void chopAndSliceIngredients(int sec)
    {
        // add state change?
        Console.WriteLine("Chopping and Slicing Ingredients for " + sec + " seconds");
    }

    public void beginPlacingIngredients()
    {
        changeToState(state.processEvent(2));
        // perform all actions for sandwich setup
        Console.WriteLine("Placing Ingredients..."); 
    }

    public void endPlacingIngredients()
    {
		// Go to next state based on sandwich
		if (sandwich.getNeedsToasting()) // Toast next.
		{
			changeToState(state.processEvent(3));
		}
		else // don't toast. move straight to wrapping
		{
			changeToState(state.processEvent(4));
		}
	}

    public void toastSandwich(int sec)
    {
        Console.WriteLine($"Toasting sandwich ${sec}");
        // Wrap next
        changeToState(state.processEvent(4));
    }   
    public void wrapSandwich() 
    {
		// Go to order complete
		changeToState(state.processEvent(5));
    }
    public string getJobState()
    {
        return state.ToString();
    }
}