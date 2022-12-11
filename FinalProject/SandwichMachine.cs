/**
 * This class represents a machine designed to automatically make sandwiches
 * based on the orders of a customer.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using FinalProject;
using System.Reflection;
using System.Runtime.Serialization;
using Serilog;

class SandwichMachine : SandwichMachineIF
{
    private AbstractSandwich sandwich;
    private List<Order> customerQueue;
    private List<Order> preparingQueue;
    private Queue<SandwichEnvIF> freeProcessingAreas;
    private Dictionary<int, Order> pickupList;
    private ReadWriteLock machineLock = new ReadWriteLock();

    public SandwichMachine()
    {
        customerQueue = new List<Order>();
        preparingQueue = new List<Order>();
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

	public OrderStatus getOrderStatus(int orderNum)
	{
        try
        {
            machineLock.readLock();
            //string status;
            //Order currentOrder;

            // Find sandwich
            if (pickupList.ContainsKey(orderNum)) // Finished.
            {
                machineLock.done();
                return OrderStatus.Ready;
                // currentOrder = pickupList[orderNum];
            } else if (preparingQueue.Count > 0) { // Being made.
                foreach (Order o in preparingQueue)
                {
                    if (orderNum == o.getOrderNumber())
                    {
                        machineLock.done();
                        return OrderStatus.Preparing;
                    }
                }
            } else if (customerQueue.Count > 0)
            {
                foreach (Order o in preparingQueue)
                {
                    if (orderNum == o.getOrderNumber())
                    {
                        machineLock.done();
                        return OrderStatus.Waiting;
                    }
                }
            }
            machineLock.done();
            return OrderStatus.Invalid_Order;

            /*
            List<Order> orders = createOrderList(order, preparingQueue);
            int orderIndex = orders.IndexOf(order);
            currentOrder = orders[orderIndex];
            // currentOrder = order;
            }

            /*
            List<AbstractSandwich> sandwiches = currentOrder.getSandwiches();
            string status;

			for (int i = 0; i < sandwiches.Count; i++)
            {
				status = sandwiches[i].getSandwichEnv().getJobState();
                if (!type(status).IsInstanceOfType(SandwichCompleted))
                {
                    machineLock.done();
                    return status.ToString();
                }
			}
			machineLock.done();
            */
        }
        catch (ThreadInterruptedException e)
        {
            Log.Error(e.ToString());
            return OrderStatus.Invalid_Order;
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
		customerQueue.Add(order);
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
			Order order = customerQueue[0];
            customerQueue.RemoveAt(0);
            Log.Information("Picking up order {num} to process.", order.getOrderNumber());
			preparingQueue.Add(order);
            machineLock.done();

			await foreach (bool orderStarted in beginProcessingOrder(order));
		}
        //throw new MachineException("No processing areas free.");
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
                freeProcessingAreas.Enqueue(s.getSandwichEnv());
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

    /*
	private List<Order> createOrderList(Order order, List<Order> q)
    {
		List<Order> orders = q.ToArray().ToList();
        return orders;
	}
    */

    public void CompleteOrder(Order order)
    {
        if (preparingQueue.Contains(order))
        {
            // Remove the order from the prepartion area.
			preparingQueue.Remove(order);
		}
        // Add to Pickup List
        pickupList.Add(order.getOrderNumber(), order);
        Log.Information("Completed Order #{num}", order.getOrderNumber());
    }

    public Order PickupOrder(int orderNum)
    {
        Order o = pickupList[orderNum];
        pickupList.Remove(orderNum);
        return o;
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
