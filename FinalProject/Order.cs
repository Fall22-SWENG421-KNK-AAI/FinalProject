/**
 * This class represents a sandwich order that a customer can make.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
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
		Order.orderNumber++;
	}

	public Order()
	{
		sandwiches = new List<AbstractSandwich>();
        thisOrderNumber = orderNumber;
		Order.orderNumber++;
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
