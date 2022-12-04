class PlacingIngredients : JobState
{
    private JobState parent;

    JobState nextState(int x)
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
                wrapping;
                break;
        }
    }

}
