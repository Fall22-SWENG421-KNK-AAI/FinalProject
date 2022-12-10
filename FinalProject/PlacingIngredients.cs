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
