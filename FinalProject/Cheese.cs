public abstract class Cheese
{
    protected string name;
    protected double price;

    public virtual string addCheese()
    {
        return $"{name} added";
    }

    public virtual string removeCheese()
    {
        return $"{name} removed";
    }
}