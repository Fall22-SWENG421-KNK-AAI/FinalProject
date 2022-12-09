class American : Topping, Cheese
{
    public American()
    {
        name = "American Cheese";
        price = 0.99;
    }

    public void addCheese()
    {
        addTopping();
    }

    public void removeCheese()
    {
        removeTopping();
	}
}
