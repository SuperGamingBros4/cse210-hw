public class DailyGoal : EternalGoal
{
    private DateTime _completedDay = new DateTime();

    public DailyGoal() : base()
    {
 
    }
    public DailyGoal(List<string> rowValues) : base(rowValues)
    {

    }

    public override string GetGoalType()
    {
        return "DailyGoal";
    }
    public override int GetPoints()
    {
        int points = base.GetPoints();
        DateTime currentDate = DateTime.Today;

        // If today is the next day in the streak, give a 50% points multiplier
        if (currentDate == _completedDay)
            points = (int)(points * 1.5);

        // Move the streak date to the next day
        _completedDay = currentDate.AddDays(1).Date;

        return points;
    }
    public override string Serialize()
    {
        string formattedDate = _completedDay.ToShortDateString();

        // Serialize the goal to be saved
        return $"{base.Serialize()},{formattedDate}";
    }
    protected override void Deserialize(List<string> rowValues)
    {
        // Load the common values
        base.Deserialize(rowValues);

        // Parse the date from the file
        _completedDay = DateTime.Parse(rowValues[4]);
    }
}