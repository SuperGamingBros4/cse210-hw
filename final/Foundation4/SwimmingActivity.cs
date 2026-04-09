public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(string date, double minutes, int laps)
        : base(date, minutes)
    {
        // Set the attributes
        _laps = laps;
    }

    public override string GetActivityType()
    {
        return "Swimming";
    }
    public override double GetDistance()
    {
        // Return the distance of the activity in km
        // Each lap is 50m
        return _laps * 50 / 1000;
    }
}