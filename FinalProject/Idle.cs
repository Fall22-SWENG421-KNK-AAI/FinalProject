class Idle : JobState
{
    private JobState parent;
    public JobState nextState(int x)
    {
        //set the next state
        return placingIngredients;
    }
}
