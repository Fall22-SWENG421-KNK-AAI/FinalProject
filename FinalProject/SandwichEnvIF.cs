public interface SandwichEnvIF
{
    public void setBread(string type);
	public void placeCheese(int slices);
	public void placeProtein(int pieces, string type);
	public void addToppings(Array[] ToppingIF);
	public void toastSandwich(int sec);
	public string getJobState();
}