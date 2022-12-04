class JobState
{
    protected Idle idle;
    protected Wrapping wrapping;
    protected Toasting toasting;
    protected PlacingIngredients placingIngredients;
    protected OrderCompleted ordercompleted;
    public readonly int idleEvent = 1;
    public readonly int placingIngredientsEvent = 2;
    public readonly int toastingEvent = 3;
    public readonly int wrappingEvent = 4;
    public readonly int orderCompletedEvent = 5;
    public readonly int machineErrorEvent = 6;


    protected void enter() { }
    protected abstract void nextState(int x);
    public JobState processEvent(int x)
    {
        {
            //process the event
            nextState(x);
            return this;
        }
    }
}
