using FinalProject;

public interface SandwichCreatorIF 
{
    public Order createSandwich(string s);
    public string getSandwichStatus(Order order);
    public void AddOrderToQueue(Order order);
    public Order PickOrder();
    public void CompleteOrder(Order order);
}