/**
 * This class represents a sandwich containing assorted meats.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using FinalProject;

class MeatLovers : AbstractSandwich
{

    public MeatLovers()
    {
        name = "Meat Lovers";
        price = 8.99;
        description = "A delicious sandwich with roastbeef, turkey, veggie patty, and cheese.";
        toastTime = 60;
        needsToasting = true;
    }

    public override void start()
    {
        getSandwichEnv().beginPlacingIngredients();
        getSandwichEnv().placeBread(new Wheat());
        getSandwichEnv().placeCheese(new Cheddar(), 2);
        getSandwichEnv().placeProtein(new RoastBeef(), 1);
        getSandwichEnv().placeProtein(new Turkey(), 1);
        getSandwichEnv().placeProtein(new VeggiePatty(), 1);
        getSandwichEnv().endPlacingIngredients();
        getSandwichEnv().toastSandwich(toastTime);
        getSandwichEnv().wrapSandwich();
    }
}

