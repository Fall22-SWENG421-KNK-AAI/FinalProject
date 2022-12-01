using FinalProject;
using System.ComponentModel.Design.Serialization;

class SandwichCreator : SandwichCreatorIF
{
    private JobState state;
    private ReadWriteLock Lock;

    public AbstractSandwich createSandwich(string s)
    {
        //create a new sandwich
        AbstractSandwich sandwich;
        if (s.Equals("Veggie"))
        {
            sandwich = new VeggieDelight();
        }
        else if (s.Equals("Meat"))
        {
            sandwich = new MeatLovers();
        }
        else if (s.Equals("Classic"))
        {
            sandwich = new TheClassic();
        }
        else if (s.Equals("Spicy"))
        {
            sandwich = new PlainSpicy();
        }
        else if (s.Equals("Vegan"))
        {
            sandwich = new forVegans();
        }
        else
        {
            sandwich = null; // add Null Object based sandwich?
        }
        //return the sandwich
        return sandwich;
    }

    public string getSandwichStatus()
    {
        //return the status of the sandwich
        return state.ToString();
    }

    public void setSandwichStatus(string s)
    {
        
    }
}
