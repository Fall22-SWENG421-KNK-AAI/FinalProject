using FinalProject;

class TheClassic : AbstractSandwich
{

    public TheClassic()
    {
        name = "The Classic";
        price = 6.99;
        description = "A delicious sandwich with roastbeef, turkey, and cheese.";
        totalRuntime = 6 * secsInMin;
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
        getSandwichEnv().toastSandwich(180);
        getSandwichEnv().wrapSandwich();
    }
}

