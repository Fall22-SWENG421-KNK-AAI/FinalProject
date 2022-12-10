using FinalProject;

public class Order
{
	private static int orderNumber = 1;
	private int thisOrderNumber;
	private List<AbstractSandwich> sandwiches;

	public Order(AbstractSandwich sandwich)
	{
		sandwiches = new List<AbstractSandwich>() { sandwich };
		thisOrderNumber = orderNumber;
		orderNumber++;
	}

	public Order()
	{
		sandwiches = new List<AbstractSandwich>();
        thisOrderNumber = orderNumber;
		orderNumber++;
    }

	public List<AbstractSandwich> getSandwiches()
	{
		return sandwiches;
	}

	public int getOrderNumber()
	{
		return thisOrderNumber;
	}

	public void AddSandwich(AbstractSandwich s)
	{
		sandwiches.Add(s);
	}
}
