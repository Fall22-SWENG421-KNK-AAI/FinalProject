public class PlacingIngredients : JobState
{
    protected override JobState nextState(int x)
    {
        //set the next state
        switch (x) {
            case toastingEvent:
                return toasting;
                break;
            case wrappingEvent:
                return wrapping;
                break;
            default:
                return wrapping;
                break;
        }
    }
}
