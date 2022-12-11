/**
 * This class represents the wrapping state of the sandwich machine.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
public class Wrapping : JobState
{
    protected override JobState nextState(int x)
    {
        SandwichCompleted s = new SandwichCompleted();
        context.changeTo(s);
        return s;
    }
}
