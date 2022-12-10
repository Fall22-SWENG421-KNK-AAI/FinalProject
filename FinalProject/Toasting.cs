public class Toasting : JobState
{
    protected override JobState nextState(int x)
    {
        Wrapping w = new Wrapping();
        context.changeTo(w);
        return w;
    }

}
