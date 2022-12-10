using FinalProject;

public interface SandwichEnvIF
{
	public void setSandwich(AbstractSandwich sandwich);
    public void placeBread(Bread type);
	public void placeCheese(Cheese type, int slices);
	public void placeProtein(Protein type, int pieces);
	public void addToppings(Topping[] t);
	public string beginPlacingIngredients();
	public void endPlacingIngredients();
	public string toastSandwich(int sec);
	public string wrapSandwich();
	public JobState getJobState();
	public void changeTo(JobState state);
}