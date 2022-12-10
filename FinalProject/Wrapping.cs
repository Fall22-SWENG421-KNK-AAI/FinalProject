public class Wrapping : JobState
{
    protected override JobState nextState(int x)
    {
        SandwichCompleted s = new SandwichCompleted();
        context.changeTo(s);
        return s;
    }
}
