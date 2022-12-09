using FinalProject;

public class Order
{
	private static int orderNumber = 1;
	private AbstractSandwich sandwich;

	public Order(AbstractSandwich sandwich)
	{
		this.sandwich = sandwich;
		orderNumber++;
	}

	public AbstractSandwich getSandwich()
	{
		return sandwich;
	}

	public int getOrderNumber()
	{
		return orderNumber;
	}
}
