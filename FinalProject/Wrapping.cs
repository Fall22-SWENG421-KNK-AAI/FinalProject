public class Wrapping : JobState
{
    protected override JobState nextState(int x)
    {
        OrderCompleted o = new OrderCompleted();
        context.changeTo(o);
        return o;
    }
}
