public class Lecture : Event
{
    private string _speakerName;
    private int _capacity;

    public Lecture(string title, string description, Address address, string date, string time, string speakerName, int capacity)
        : base(title, description, address, date, time)
    {
        // Set the attributes
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public override string GetEventType()
    {
        return "Lecture";
    }
    public override string GetFullDetails()
    {
        // Create a description of the details based on the standard details, the speaker, and the capacity of the event
        string details = GetDetails();
        details += $"\n  Speaker: {_speakerName} - Max occupancy: {_capacity}";

        return details;
    }
}