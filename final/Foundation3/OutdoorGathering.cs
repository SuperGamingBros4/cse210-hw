public class OutdoorGathering : Event
{
    private string _forecast;

    public OutdoorGathering(string title, string description, Address address, string date, string time, string forecast)
        : base(title, description, address, date, time)
    {
        // Set the attributes
        _forecast = forecast;
    }

    public override string GetEventType()
    {
        return "Outdoor gathering";
    }
    public override string GetFullDetails()
    {
        // Create a description of the details based on the standard details and the forecasted weather
        string details = GetDetails();
        details += $"\n  Expected weather: {_forecast}";

        return details;
    }
}