public abstract class Event
{
    private string _title;
    private string _description;
    private Address _address;
    private string _date;
    private string _time;

    public Event(string title, string description, Address address, string date, string time)
    {
        // Set the attributes
        _title = title;
        _description = description;
        _address = address;
        _date = date;
        _time = time;
    }

    public string GetShortDetails()
    {
        // Create a short marketing description of the details based on the title, event type, and date
        string details = $"{GetEventType()}: {_title} | {_date}";

        return details;
    }
    public string GetDetails()
    {
        // Get the address display
        string addressDisplay = _address.GetInlineDisplay();

        // Create a description of the details based on the title, address, date, time, and description of the event
        string details = $"{_title}";
        details += $"\n  {_description}";
        details += $"\n  {_date} {_time}";
        details += $"\n  {addressDisplay}";

        return details;
    }

    public abstract string GetEventType();
    public abstract string GetFullDetails();
}