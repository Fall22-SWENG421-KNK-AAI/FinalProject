/**
 * This class represents the state that the sandwich machine reach
 * once the machine is finished making a sandwich.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
public class SandwichCompleted : JobState
{
    protected override JobState nextState(int x)
    {
        Idle i = new Idle();
        context.changeTo(i);
        return i;
    }
}
