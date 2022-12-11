/**
 * This class represents the lunch special of the sandwich shop.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using FinalProject;

class TheClassic : AbstractSandwich
{

    public TheClassic()
    {
        name = "The Classic";
        price = 6.99;
        description = "A delicious sandwich with roastbeef, turkey, and cheese.";
        toastTime = 45;
        needsToasting = true;
    }

    public override void start()
    {
        getSandwichEnv().beginPlacingIngredients();
        getSandwichEnv().placeBread(new Wheat());
        getSandwichEnv().placeCheese(new American(), 1);
        getSandwichEnv().placeProtein(new RoastBeef(), 2);
        getSandwichEnv().placeProtein(new Turkey(), 1);
        Topping[] toppings = {
            new Mayonnaise(),
            new Lettuce(), new Lettuce(), new Lettuce(), new Lettuce(),
            new Tomato(), new Tomato(), new Tomato()
        };
        getSandwichEnv().addToppings(toppings);
        getSandwichEnv().endPlacingIngredients();
        getSandwichEnv().toastSandwich(toastTime);
        getSandwichEnv().wrapSandwich();
    }
}

