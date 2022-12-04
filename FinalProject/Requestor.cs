using FinalProject;

public class Requestor
{
    private AbstractSandwich sandwich;
    private SandwichCreator creator = new SandwichCreator();

    public AbstractSandwich orderSandwich(string sandwich)
    {
        return creator.createSandwich(sandwich);
    }
}
