using FinalProject;

class SandwichCreator : SandwichCreatorIF
{
    private AbstractSandwich sandwich;
    private Queue<Order> customerQueue;
    private Queue<Order> preparingQueue;
    private Dictionary<int, Order> pickupList;
    private ReadWriteLock machineLock = new ReadWriteLock();

	public string getSandwichStatus(Order order)
	{
        try
        {
            machineLock.readLock();
            string status;
            int orderNum = order.getOrderNumber();
            AbstractSandwich sandwich;

            // Find sandwich
            if (pickupList.ContainsKey(orderNum)) // Finished.
            {
                sandwich = pickupList[orderNum].getSandwich();
			} else if (preparingQueue.Contains(order)) { // Being made.
				List<Order> orders = createOrderList(order, preparingQueue);
				int orderIndex = orders.IndexOf(order);
				sandwich = orders[orderIndex].getSandwich();
            } else // Hasn't been started.
            {
                sandwich = order.getSandwich();
            }
			status = sandwich.getSandwichEnv().getJobState();
			machineLock.done();
            return status;
        }
        catch (ThreadInterruptedException e)
        {
            return e.Message;
        }
	}
    
    public Order createSandwich(string s)
    {
        machineLock.writeLock();
        Type type = Type.GetType(s);
        Object obj = Activator.CreateInstance(type);
        sandwich = (AbstractSandwich)obj;
        Order order = new(sandwich);
        machineLock.done();
        return order;
        
    }

	public void AddOrderToQueue(Order order)
    {
        customerQueue.Enqueue(order);
	}

    public Order PickOrder()
    {
        Order order = customerQueue.Dequeue();
        preparingQueue.Enqueue(order);
        return order;
    }

    public List<Order> createOrderList(Order order, Queue<Order> q)
    {
		List<Order> orders = q.ToArray().ToList();
        return orders;
	}

    public void CompleteOrder(Order order)
    {
        List<Order> orders = createOrderList(order, preparingQueue);
        if (orders.Contains(order))
        {
            // Remove the order from the prepartion area.
			orders.Remove(order);
            preparingQueue = new Queue<Order>(orders);
		}
        // Add to Pickup List
        pickupList.Add(order.getOrderNumber(), order);
    }
}
