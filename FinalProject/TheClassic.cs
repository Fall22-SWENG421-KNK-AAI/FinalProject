using FinalProject;

class TheClassic : AbstractSandwich
{

    public TheClassic()
    {
        name = "The Classic";
        price = 5.99;
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
        getSandwichEnv().chopAndSliceIngredients(30);
        getSandwichEnv().addToppings(toppings);
        getSandwichEnv().endPlacingIngredients();
        getSandwichEnv().toastSandwich(180);
        getSandwichEnv().wrapSandwich();
    }
}

