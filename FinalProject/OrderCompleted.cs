
public class OrderCompleted : JobState
{
    protected override JobState nextState(int x)
    {
        Idle i = new Idle();
        context.changeTo(i);
        return i;
    }
}
