using FinalProject;

public class Order
{
	private static int orderNumber = 1;
	private List<AbstractSandwich> sandwiches;

	public Order(AbstractSandwich sandwich)
	{
		sandwiches = new List<AbstractSandwich>() { sandwich };
		orderNumber++;
	}

	public Order()
	{
		sandwiches = new List<AbstractSandwich>();
		orderNumber++;
	}

	public List<AbstractSandwich> getSandwiches()
	{
		return sandwiches;
	}

	public int getOrderNumber()
	{
		return orderNumber;
	}

	public void AddSandwich(AbstractSandwich s)
	{
		sandwiches.Add(s);
	}
}
