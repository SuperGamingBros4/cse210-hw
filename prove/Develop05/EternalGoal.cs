public class EternalGoal : Goal
{
    public EternalGoal() : base()
    {

    }
    public EternalGoal(List<string> rowValues) : base(rowValues)
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
    public override string Serialize()
    {
        // Serialize the goal to be saved
        return $"EternalGoal,{base.Serialize()}";
    }
    protected override void Deserialize(List<string> rowValues)
    {
        // Load the common values
        base.Deserialize(rowValues);
    }
}