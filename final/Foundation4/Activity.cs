public abstract class Activity
{
    private string _date;
    protected double _minutes;

    public Activity(string date, double minutes)
    {
        // Set the attributes
        _date = date;
        _minutes = minutes;
    }

    public virtual double GetSpeed()
    {
        // Return the average speed of the event in kph
        return GetDistance() / _minutes * 60;
    }
    public double GetPace()
    {
        // Return the average pace of the event in min/km
        return _minutes / GetDistance();
    }
    public string GetSummary()
    {
        // Get the different values to display
        string activityType = GetActivityType();
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{_date} {activityType} ({_minutes:0.#} min) - Distance {distance:0.##} km, Speed {speed:0.##} kph, Pace {pace:0.##} min per km";
    }

    public abstract string GetActivityType();
    public abstract double GetDistance();
}