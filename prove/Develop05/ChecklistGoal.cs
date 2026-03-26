public class ChecklistGoal : Goal
{
    protected int _completedCount = 0;
    protected int _maxComplete = 0;
    protected int _bonusPoints = 0;

    public ChecklistGoal() : base()
    {

    }

    protected override void Prompt()
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
        _maxComplete = maxComplete;
        _bonusPoints = bonusPoints;
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
}