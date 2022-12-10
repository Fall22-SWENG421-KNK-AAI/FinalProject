using FinalProject;
using System.Reflection;
using System.Runtime.Serialization;

class SandwichMachine : SandwichMachineIF
{
    private AbstractSandwich sandwich;
    private Queue<Order> customerQueue;
    private Queue<Order> preparingQueue;
    private Queue<SandwichEnvIF> freeProcessingAreas;
    private Dictionary<int, Order> pickupList;
    private ReadWriteLock machineLock = new ReadWriteLock();

    public SandwichMachine()
    {
        customerQueue = new Queue<Order>();
        preparingQueue = new Queue<Order>();
        freeProcessingAreas = new Queue<SandwichEnvIF>();
        pickupList = new Dictionary<int, Order>();


        for (int i = 0; i < 3; i++)
        {
            freeProcessingAreas.Enqueue(new SandwichEnv(this));
        }
	}

    public bool processingAreaFree()
    {
        machineLock.readLock();
        foreach (SandwichEnvIF env in freeProcessingAreas)
        {
            if (typeof(Idle).IsInstanceOfType(env.getJobState())) // Machine is Idle
            {
                machineLock.done();
                return true;
            }
        }
        machineLock.done();
        return false;
    }

	private SandwichEnvIF getFreeProcessingArea()
    {
        machineLock.writeLock();
        SandwichEnvIF env = freeProcessingAreas.Dequeue();
        machineLock.done();
        return env;
    }

	public string[] getSandwichStatus(Order order)
	{
        try
        {
            machineLock.readLock();
            string status;
            int orderNum = order.getOrderNumber();
			Order currentOrder;

			// Find sandwich
			if (pickupList.ContainsKey(orderNum)) // Finished.
            {
                currentOrder = pickupList[orderNum];
			} else if (preparingQueue.Contains(order)) { // Being made.
				List<Order> orders = createOrderList(order, preparingQueue);
				int orderIndex = orders.IndexOf(order);
				currentOrder = orders[orderIndex];
            } else // Hasn't been started.
            {
				currentOrder = order;
            }

            List<AbstractSandwich> sandwiches = currentOrder.getSandwiches();
            string[] statuses = new string[] { };

			for (int i = 0; i < sandwiches.Count; i++)
            {
				status = sandwiches[i].getSandwichEnv().getJobState().ToString();
                statuses.Append(status);
			}
			machineLock.done();
            return statuses;
        }
        catch (ThreadInterruptedException e)
        {
            Console.WriteLine(e.ToString());
            return new string[] {""};
        }
	}
    
    private AbstractSandwich createSandwich(string s)
    {
        machineLock.writeLock();
        // Factory method
        Type type = Type.GetType(s);
        Object obj = Activator.CreateInstance(type);
        sandwich = (AbstractSandwich)obj;
        return sandwich;
    }

    public Order AddSandwichToOrder(string s, Order order)
    {
        machineLock.writeLock();
		order.AddSandwich(createSandwich(s));
        machineLock.done();

        return order;
    }

	private void AddOrderToQueue(Order order)
	{
		customerQueue.Enqueue(order);
	}

	public void PlaceOrder(Order order)
    {
		machineLock.writeLock();
		AddOrderToQueue(order);
		machineLock.done();
	}

    // This will run in the background constantly.
    public async void PickOrder()
    {
        if (processingAreaFree() && customerQueue.Count > 0)
        {
            machineLock.writeLock();
			Order order = customerQueue.Dequeue();
			preparingQueue.Enqueue(order);
            machineLock.done();

			await foreach (bool orderStarted in beginProcessingOrder(order));
		}
        //throw new MachineException("No processing areas free.");
        //Console.WriteLine("No processing areas free.");
    }

    // This will run to start the processing of an order
    // When it finishes processing one sandwich it will
    // move onto the next one in the same order and process it.
    // That's what the yield return is for.
    private async IAsyncEnumerable<bool> beginProcessingOrder(Order o)
    {
        foreach (AbstractSandwich s in o.getSandwiches())
		{
			if (processingAreaFree())
			{
                yield return await startProcessingSandwich(s);
			}
		}

        CompleteOrder(o);
    }

    // This processes an individual sandwich asynchronously so we can use UI at same time.
	private async Task<bool> startProcessingSandwich(AbstractSandwich sandwich)
	{
        return await Task.Run(() =>
        {
			//machineLock.writeLock();
			var env = getFreeProcessingArea();
			sandwich.setEnvironment(env);
			//machineLock.done();
			sandwich.start();
			return true;
		});
	}

	private List<Order> createOrderList(Order order, Queue<Order> q)
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

	[Serializable]
	public class MachineException : Exception
	{
		public MachineException()
		{
		}

		public MachineException(string? message) : base(message)
		{
		}

		public MachineException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected MachineException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
