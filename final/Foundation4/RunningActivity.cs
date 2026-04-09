public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(string date, double minutes, double distance)
        : base(date, minutes)
    {
        // Set the attributes
        _distance = distance;
    }

    public override string GetActivityType()
    {
        return "Running";
    }
    public override double GetDistance()
    {
        // Return the distance of the activity in km
        return _distance;
    }
}