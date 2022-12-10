using System.Runtime.CompilerServices;
using System.Threading;
using Serilog;
public class ReadWriteLock
{
    private int waitingForRead = 0;
    private int outstandingReadLocks = 0;
    private Thread writerLockedThread;
    private List<Thread> waitingForWriting = new List<Thread>();

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void readLock()
    {
        try
        {
            if (writerLockedThread != null)
            {
                waitingForRead++;
                while (writerLockedThread != null)
                {
                    Monitor.Wait(this);
                }
                waitingForRead--;
            }
            outstandingReadLocks++;
            Log.Information("Servicing Read Thread");
        }
        catch (ThreadInterruptedException e)
        {
            Log.Error(e.ToString());
        }
    }

    public void writeLock()
    {
        try
        {
            Thread thisThread;
            lock (this)
            {
                if (writerLockedThread == null && outstandingReadLocks == 0)
                {
                    writerLockedThread = Thread.CurrentThread;
                }
                thisThread = Thread.CurrentThread;
                waitingForWriting.Add(thisThread);
            }
            lock (thisThread)
            {
                while (thisThread != writerLockedThread)
                {
                    Monitor.Wait(thisThread);
                }
            }
            lock (this)
            {
                waitingForWriting.Remove(thisThread);
            }
            Log.Information("Servicing Write Thread");
        }
        catch (ThreadInterruptedException e)
        {
			Log.Error(e.ToString());
		}
    }

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void done()
    {
        string returnMessage = "";
        
        if(outstandingReadLocks > 0)
        {
            outstandingReadLocks--;
            if (outstandingReadLocks == 0 && waitingForWriting.Count > 0)
            {
                writerLockedThread = waitingForWriting[0];
                lock (writerLockedThread)
                {
                    Monitor.PulseAll(writerLockedThread);
                }
                returnMessage = "Servicing next Writer";
            }
        }
        else if (Thread.CurrentThread == writerLockedThread)
        {
            if (outstandingReadLocks == 0 && waitingForWriting.Count > 0)
            {
                writerLockedThread = waitingForWriting[0];
                lock (writerLockedThread)
                {
                    Monitor.PulseAll(writerLockedThread);
                }
                returnMessage = "Servicing next Writer";
            }
            else
            {
                writerLockedThread = null;
                if (waitingForRead > 0)
                {
                    Monitor.PulseAll(this);
                    returnMessage = "Notifying Read threads";
                }
                returnMessage = "No threads to service";
            }
        }
        else
        {
            throw new InvalidOperationException("Thread does not have lock");
        }

        Log.Information(returnMessage);
    }
}