using System.Runtime.CompilerServices;
using System.Threading;

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
        }
        catch (ThreadInterruptedException e)
        {
            Console.WriteLine(e.ToString());
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
                    return;
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
        }
        catch (ThreadInterruptedException e)
        {
			Console.WriteLine(e.ToString());
		}
    }

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void done()
    {
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
            }
            else
            {
                writerLockedThread = null;
                if (waitingForRead > 0)
                {
                    Monitor.PulseAll(this);
                }
            }
        }
        else
        {
            throw new InvalidOperationException("Thread does not have lock");
        }
    }
}