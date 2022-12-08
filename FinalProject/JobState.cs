public abstract class JobState
{
    protected Idle idle = new Idle();
    protected Wrapping wrapping = new Wrapping();
    protected Toasting toasting = new Toasting();
    protected PlacingIngredients placingIngredients = new PlacingIngredients();
    protected OrderCompleted orderCompleted = new OrderCompleted();
    public const int idleEvent = 1;
    public const int placingIngredientsEvent = 2;
    public const int toastingEvent = 3;
    public const int wrappingEvent = 4;
    public const int orderCompletedEvent = 5;
    public const int machineErrorEvent = 6;


    protected void enter() {
        //this.
    }

    protected abstract JobState nextState(int x);
    public JobState processEvent(int x)
    {
        {
            //process the event
            this.nextState(x);
            return this;
        }
    }
}
