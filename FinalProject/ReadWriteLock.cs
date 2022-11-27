class ReadWriteLock
{
    private int waitingForRead;
    private int waitingForWrite;
    private Thread writerLockedThread;
    private List<Thread> waitingForWriting;

    public void readLock() { }
    public void writeLock() { }
    public void done() { }
    
}