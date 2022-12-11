/**
 * This class represents the toasting state of the sandwich machine.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
public class Toasting : JobState
{
    protected override JobState nextState(int x)
    {
        Wrapping w = new Wrapping();
        context.changeTo(w);
        return w;
    }

}
