public abstract class JobState
{
    public const int idleEvent = 1;
    public const int placingIngredientsEvent = 2;
    public const int toastingEvent = 3;
    public const int wrappingEvent = 4;
    public const int sandwichCompletedEvent = 5;
    public const int machineErrorEvent = 6;

    protected SandwichEnvIF context;

    protected abstract JobState nextState(int x);
    public JobState processEvent(int x)
    {
        return nextState(x);
    }

    // help gotten from refactoring.guru/design-patterns/state/csharp/example
    public void setContext(SandwichEnvIF env)
    {
        context = env;
    }

    public override string ToString() => GetType().ToString();
}
