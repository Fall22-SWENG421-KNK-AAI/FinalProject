using FinalProject;
using System.ComponentModel.Design.Serialization;

class SandwichCreator : SandwichCreatorIF
{
    private JobState state;
    private ReadWriteLock Lock;

    public AbstractSandwich createSandwich(string s)
    {
		//create a new sandwich with Factory pattern
		Type type = Type.GetType(s);
		Object obj = Activator.CreateInstance(type);
		AbstractSandwich sandwich = (AbstractSandwich)obj;
		return sandwich;
    }

    // This doesn't really make sense.
    // 
    // because we don't initialize the state in here.
    // 
    /*public string getSandwichStatus()
    {
        //return the status of the sandwich
        return state.ToString();
    }*/
}
