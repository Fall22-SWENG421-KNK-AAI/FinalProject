
public class OrderCompleted : JobState
{
    private JobState parent;

    protected override JobState nextState(int x)
    {
        //set the next state
        return idle;
    }
}
