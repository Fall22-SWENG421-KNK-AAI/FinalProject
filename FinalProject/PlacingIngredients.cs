/**
 * This class represents one of the preparing state of the sandwich machine
 * where the machine begins placing ingredients for the sandwich.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
public class PlacingIngredients : JobState
{
    protected override JobState nextState(int x)
    {
		Wrapping w = new Wrapping();

		switch (x) {
            case toastingEvent:
                Toasting t = new Toasting();
                context.changeTo(t);
                return t;
            case wrappingEvent:
				context.changeTo(w);
				return w;
            default:
                context.changeTo(w);
                return w;
        }
    }
}
