public class SandwichEnv : SandwichEnvIF
{
    private JobState state;
    private SandwichCreatorIF creator;

    public SandwichEnv()
    {
        this.creator = new SandwichCreator();
    }

    public void setBread(string type) { }
    public void placeCheese(int slices) { }
    public void placeProtein(int pieces, string type) { }
    public void addToppings(Array[] ToppingIF) { }

    public void placeIngredients()
    {
        // perform all actions for sandwich setup


        // Go to next state based on sandwich
        if (needsToasting()) // Toast next.
        {
			state.processEvent(3);
		}
        else // don't toast. move straight to wrapping
        {
			state.processEvent(4);
		}
    }
    public void toastSandwich(int sec)
    {
        Console.WriteLine($"Toasting sandwich ${sec}");
        // Wrap next
        state.processEvent(4);
    }   
    public void wrapSandwich() 
    {
        // Go to order complete
        state.processEvent(5);
    }
    public string getJobState()
    {
        return state.ToString();
    }
    private bool needsToasting() // temp function to remove error in placeIngredients()
    {
        return true;
    }
}