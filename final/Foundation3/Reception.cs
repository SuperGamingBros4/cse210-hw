public class Reception : Event
{
    private string _emailRSVP;
    
    public Reception(string title, string description, string address, string date, string time, string emailRSVP)
        : base(title, description, address, date, time)
    {
        // Set the attributes
        _emailRSVP = emailRSVP;
    }

    public override string GetEventType()
    {
        return "Reception";
    }
    public override string GetFullDetails()
    {
        // Create a description of the details based on the standard details and the RSVP email
        string details = GetDetails();
        details += $"\n  Sign up: {_emailRSVP}";

        return details;
    }
}