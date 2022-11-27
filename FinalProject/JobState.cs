class JobState
{
    protected Idle idle;
    //protected InProgress inProgress;
    protected OrderCompleted ordercompleted;
    public int jobStateEvent = 1;
    public int machineErrorEvent = 2;


    protected void enter() { }
    protected void nextState(int x) { }
    public JobState processEvent(int x)
    {
        {
            //process the event
            nextState(x);
            return this;
        }
    }
}
