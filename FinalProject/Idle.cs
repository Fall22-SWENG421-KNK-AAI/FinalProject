public class Idle : JobState
{
    private JobState parent;
    protected override JobState nextState(int x)
    {
        //set the next state
        switch (x) {
            case placingIngredientsEvent:
                return placingIngredients;
                break;
            default:
                return idle;
                break;
        }    
    }
}
