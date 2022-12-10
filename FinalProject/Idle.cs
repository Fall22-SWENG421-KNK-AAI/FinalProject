public class Idle : JobState
{
    protected override JobState nextState(int x)
    {
        switch (x) {
            case placingIngredientsEvent:
                PlacingIngredients pl = new PlacingIngredients();
                context.changeTo(pl);
                return pl;
            default:
                context.changeTo(this);
                return this;
        }    
    }
}
