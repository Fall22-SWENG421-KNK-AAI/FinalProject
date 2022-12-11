/**
 * This class represents a spicy sandwich.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using FinalProject;

class PlainSpicy : AbstractSandwich
{

    public PlainSpicy()
    {
        name = "Plain Spicy";
        price = 7.99;
        description = "A delicious sandwich with turkey, sriracha, hot pepper, and cheese.";
        toastTime = 45;
        needsToasting = true;
    }

    public override void start()
    {
		getSandwichEnv().beginPlacingIngredients();
		getSandwichEnv().placeBread(new Wheat());
        getSandwichEnv().placeCheese(new Swiss(), 1);
        getSandwichEnv().placeProtein(new Turkey(), 2);
        Topping[] toppings = {
            new Sriracha(), new Sriracha(), new Sriracha(),
            new HotPepper(), new HotPepper(), new HotPepper() };
        getSandwichEnv().addToppings(toppings);
        getSandwichEnv().endPlacingIngredients();
        getSandwichEnv().toastSandwich(toastTime);
        getSandwichEnv().wrapSandwich();
    }
}

