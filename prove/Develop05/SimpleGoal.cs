using System.Collections.Generic;

public class SimpleGoal : Goal
{
    private bool _completed = false;

    public SimpleGoal() : base()
    {

    }
    public SimpleGoal(List<string> rowValues) : base(rowValues)
    {

    }

    public override string GetGoalType()
    {
        return "SimpleGoal";
    }
    public override bool IsComplete()
    {
        return _completed;
    }
    public override void Complete()
    {
        _completed = true;
    }
    public override string Serialize()
    {
        // Serialize the goal to be saved
        return $"{base.Serialize()},{_completed}";
    }
    protected override void Deserialize(List<string> rowValues)
    {
        // Load the common values
        base.Deserialize(rowValues);

        // Load the values from the row
        _completed = bool.Parse(rowValues[4]);
    }
}