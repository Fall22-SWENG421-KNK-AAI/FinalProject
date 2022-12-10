
using FinalProject;

class ForVegans : AbstractSandwich
{

    public ForVegans()
    {
        name = "For Vegans";
        price = 4.99;
        description = "A delicious sandwich with lettuce, tomato, pickle.";
        totalRuntime = 4 * secsInMin;
        needsToasting = false;
    }

    public override void start()
    {
		getSandwichEnv().beginPlacingIngredients();
		getSandwichEnv().placeBread(new Wheat());
        getSandwichEnv().placeCheese(new NoCheese(), 0);
        getSandwichEnv().placeProtein(new NoProtein(), 0);
        Topping[] toppings = {
            new Lettuce(), new Lettuce(), new Lettuce(),
            new Tomato(), new Tomato(),
            new Pickle(), new Pickle(), new Pickle(), new Pickle(), new Pickle(), new Pickle()};
        getSandwichEnv().addToppings(toppings);
        getSandwichEnv().endPlacingIngredients();
        getSandwichEnv().toastSandwich(180);
        getSandwichEnv().wrapSandwich();
    }

}

