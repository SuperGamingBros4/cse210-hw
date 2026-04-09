public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(string date, double minutes, double speed)
        : base(date, minutes)
    {
        // Set the attributes
        _speed = speed;
    }

    public override string GetActivityType()
    {
        return "Cycling";
    }
    public override double GetDistance()
    {
        // Return the distance of the activity in km
        return _speed * _minutes / 60;
    }
    public override double GetSpeed()
    {
        // Return the average speed of the event in kph
        return _speed;
    }
}