
public class OrderCompleted : JobState
{
    protected override JobState nextState(int x)
    {
        //set the next state
        return idle;
    }
}
