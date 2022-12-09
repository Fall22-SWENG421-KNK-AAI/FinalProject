using FinalProject;

public class Requestor
{
    private Order order;
    private SandwichCreator creator;

    public Requestor()
    {
		creator = new SandwichCreator();
	}

    public void orderSandwich(string sandwich)
    {
         order = creator.createSandwich(sandwich);
    }
}
