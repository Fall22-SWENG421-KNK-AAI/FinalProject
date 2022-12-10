using FinalProject;

public interface SandwichEnvIF
{
	public void setSandwich(AbstractSandwich sandwich);
    public void placeBread(Bread type);
	public void placeCheese(Cheese type, int slices);
	public void placeProtein(Protein type, int pieces);
	public void addToppings(Topping[] t);
	public void beginPlacingIngredients();
	public void endPlacingIngredients();
	public void toastSandwich(int sec);
	public void wrapSandwich();
	public JobState getJobState();
	public void changeTo(JobState state);
}