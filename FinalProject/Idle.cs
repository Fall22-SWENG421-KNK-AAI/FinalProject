/**
 * This class represents the idle state of the sandwich machine.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
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
