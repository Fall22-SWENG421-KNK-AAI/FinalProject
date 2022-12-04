class Wrapping : JobState
{
    private JobState parent;

    JobState nextState(int x)
    {
        //set the next state
        return orderCompleted;
    }
}
