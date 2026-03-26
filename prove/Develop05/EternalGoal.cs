public class EternalGoal : Goal
{
    public EternalGoal() : base()
    {

    }

    public override bool IsComplete()
    {
        // Always return false. EternalGoal can never be completed
        return false;
    }
    public override void Complete()
    {
       // Do nothing 
    }
}