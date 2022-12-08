using FinalProject;
using System.ComponentModel.Design.Serialization;

class SandwichCreator : SandwichCreatorIF
{
    private AbstractSandwich sandwich;
    private ReadWriteLock machineLock = new ReadWriteLock();

	public string getSandwichStatus()
	{
		machineLock.readLock();
		string status = sandwich.ToString();
		machineLock.done();
		//return the status of the sandwich
		return status;
	}
    public void setSandwichStatus(string s)
    {
        return;
    }
    public AbstractSandwich createSandwich(string s)
    {
		machineLock.writeLock();
		//create a new sandwich with Factory pattern
		Type type = Type.GetType(s);
		Object obj = Activator.CreateInstance(type);
		this.sandwich = (AbstractSandwich)obj;
		machineLock.done();
		// Return created sandwich
		return sandwich;
    }
}
