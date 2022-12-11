/**
 * This class represents a vegetarian sandwich.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using FinalProject;

public class VeggieDelight : AbstractSandwich
{  
    
    public VeggieDelight()
    {
        name = "Veggie Delight";
        price = 5.99;
        description = "A delicious sandwich with lettuce, tomato, pickle, and cheese.";
        toastTime = 0;
		needsToasting = false;
	}

    public override void start()
    {
        getSandwichEnv().beginPlacingIngredients();
        getSandwichEnv().placeBread(new Wheat());
        getSandwichEnv().placeCheese(new Provolone(), 1);
        getSandwichEnv().placeProtein(new VeggiePatty(), 2);
        Topping[] toppings = new Topping[] {
            new Lettuce(), new Lettuce(), new Lettuce(),
            new Tomato(), new Tomato(),
            new Pickle(), new Pickle(), new Pickle(), new Pickle(), new Pickle(), new Pickle() };
        getSandwichEnv().addToppings(toppings);
        getSandwichEnv().endPlacingIngredients();
        getSandwichEnv().toastSandwich(toastTime);
        getSandwichEnv().wrapSandwich();
    }

}

