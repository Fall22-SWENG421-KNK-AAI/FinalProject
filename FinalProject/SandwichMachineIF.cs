/**
 * This interface is implemented by the SandwichMachine class.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using FinalProject;

public interface SandwichMachineIF 
{
    public void PlaceOrder(Order s);
	public Order AddSandwichToOrder(string s, Order o);
	public OrderStatus getOrderStatus(int orderNum);
	public void PickOrder();
	public void CompleteOrder(Order order);
	public Order PickupOrder(int orderNum);
}