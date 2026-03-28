using System;

public class ChecklistGoal : Goal
{
    private int _completedCount = 0;
    private int _maxComplete = 0;
    private int _bonusPoints = 0;

    public ChecklistGoal() : base()
    {

    }
    public ChecklistGoal(List<string> rowValues) : base(rowValues)
    {

    }

    public override string GetGoalType()
    {
        return "ChecklistGoal";
    }
    public override void Prompt()
    {
        // Prompt for the common elements
        base.Prompt();
        
        // Prompt for the max amount of completions
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int maxComplete = int.Parse(Console.ReadLine());

        // Prompt for the bonus when fully completing the goal
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int bonusPoints = int.Parse(Console.ReadLine());

        // Set the class attributes
        SetMaxComplete(maxComplete);
        SetBonusPoints(bonusPoints);
    }
    private void SetMaxComplete(int maxComplete)
    {
        if (maxComplete > 0)
        {
            _maxComplete = maxComplete;
        }
        else
        {
            _maxComplete = 0;
        }
    }
    private void SetBonusPoints(int bonusPoints)
    {
        if (bonusPoints > 0)
        {
            _bonusPoints = bonusPoints;
        }
        else
        {
            _bonusPoints = 0;
        }
    }
    public override int GetPoints()
    {
        // Get the base amount of points
        int points = base.GetPoints();

        // Add the bonus if the activity is complete
        if (IsComplete())
            points += _bonusPoints;

        return points;
    }
    public override string GetDisplay()
    {
        string originalDisplay = base.GetDisplay();

        return originalDisplay + $" -- Currently completed: {_completedCount}/{_maxComplete}";
    }
    public override bool IsComplete()
    {
        // The goal is complete when it has reached the amount for the bonus
        return _completedCount == _maxComplete;
    }
    public override void Complete()
    {
        if (!IsComplete())
        {
            // Only increment _completedCount if the activity is not complete
            // to avoid going over the goal
            _completedCount++;
        }
    }
    public override string Serialize()
    {
        // Serialize the goal to be saved
        return $"{base.Serialize()},{_completedCount},{_maxComplete},{_bonusPoints}";
    }
    protected override void Deserialize(List<string> rowValues)
    {
        // Load the common values
        base.Deserialize(rowValues);

        // Load the values from the row
        _completedCount = int.Parse(rowValues[4]);
        _maxComplete = int.Parse(rowValues[5]);
        _bonusPoints = int.Parse(rowValues[6]);
    }
}