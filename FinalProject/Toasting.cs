public class Toasting : JobState
{
    private JobState parent;
   
    protected override JobState nextState(int x)
    {
        //set the next state
        return wrapping;
    }

}
