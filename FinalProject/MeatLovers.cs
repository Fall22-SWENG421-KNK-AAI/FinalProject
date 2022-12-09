using FinalProject;

class MeatLovers : AbstractSandwich
{

    public MeatLovers()
    {
        name = "Meat Lovers";
        price = 6.99;
        description = "A delicious sandwich with roastbeef, turkey, veggie patty, and cheese.";
        totalRuntime = 8 * secsInMin;
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
        getSandwichEnv().toastSandwich(totalRuntime);
        getSandwichEnv().wrapSandwich();
    }
}

