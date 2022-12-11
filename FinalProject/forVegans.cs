/**
 * This class represents a vegan sandwich.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using FinalProject;

class ForVegans : AbstractSandwich
{

    public ForVegans()
    {
        name = "For Vegans";
        price = 4.99;
        description = "A delicious sandwich with lettuce, tomato, pickle.";
        toastTime = 0;
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
        getSandwichEnv().toastSandwich(toastTime);
        getSandwichEnv().wrapSandwich();
    }

}

