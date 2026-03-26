public class SimpleGoal : Goal
{
    private bool _completed = false;

    public SimpleGoal() : base()
    {

    }
    
    public override bool IsComplete()
    {
        return _completed;
    }
    public override void Complete()
    {
        _completed = true;
    }
}