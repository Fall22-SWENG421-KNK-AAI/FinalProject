interface SandwichEnvIF
{
    void setBread(string type);
    void placeCheese(int slices);
    void placeProtein(int pieces, string type);
    void addToppings(Array[] ToppingIF);
    void toastSandwich(int sec);
    
}