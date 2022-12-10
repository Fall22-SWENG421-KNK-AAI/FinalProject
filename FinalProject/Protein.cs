public abstract class Protein
{    
    protected string name;
    protected double price;

    public virtual string addProtein()
    {
        return $"{name} added";
    }

    public virtual string removeProtein()
    {
        return $"{name} removed";
    }
}
