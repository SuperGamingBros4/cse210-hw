public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }
    public Address GetAddress()
    {
        return _address;
    }
    
    public bool IsInUSA()
    {
        return GetAddress().IsInUSA();
    }
    public string GetShippingLabel()
    {
        string name = GetName();
        string addressDisplay = GetAddress().GetDisplay();

        // Return the customer's name and address
        return $"{name}\n{addressDisplay}";
    }
}