using FinalProject;

public interface SandwichMachineIF 
{
    public void PlaceOrder(Order s);
	public Order AddSandwichToOrder(string s, Order o);
	public string[] getSandwichStatus(Order order);
	public void PickOrder();
	public void CompleteOrder(Order order);
}