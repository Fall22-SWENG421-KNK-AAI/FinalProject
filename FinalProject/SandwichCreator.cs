using FinalProject;
using System.ComponentModel.Design.Serialization;

class SandwichCreator : SandwichCreatorIF
{
    private JobState state;
    private ReadWriteLock Lock;

    public AbstractSandwich createSandwich(string s)
    {
        //create a new sandwich
        AbstractSandwich sandwich = new AbstractSandwich();      
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
