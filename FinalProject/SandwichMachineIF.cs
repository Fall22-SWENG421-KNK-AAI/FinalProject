using FinalProject;

public interface SandwichMachineIF 
{
    public void PlaceOrder(Order s);
	public Order AddSandwichToOrder(string s, Order o);
	public string getOrderStatus(int orderNum);
	public void PickOrder();
	public void CompleteOrder(Order order);
	public Order PickupOrder(int orderNum);
}