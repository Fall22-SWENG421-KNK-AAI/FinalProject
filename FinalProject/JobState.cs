/**
 * This abstract class acts as the superclass to the Idle, PlacingIngredients,
 * Toasting, Wrapping, and SandwichCompleted classes.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
public abstract class JobState
{
    protected const int idleEvent = 1;
	protected const int placingIngredientsEvent = 2;
	protected const int toastingEvent = 3;
	protected const int wrappingEvent = 4;
	protected const int sandwichCompletedEvent = 5;
	protected const int machineErrorEvent = 6;

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
