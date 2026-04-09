public class Address
{
    private string _streetAddress;
    private string _city;
    private string _provinceOrState;
    private string _country;

    public Address(string streetAddress, string city, string provinceOrState, string country)
    {
        // Set the attributes
        _streetAddress = streetAddress;
        _city = city;
        _provinceOrState = provinceOrState;
        _country = country;
    }
    public Address(string streetAddress, string city, string provinceOrState)
    {
        // Assumed country is USA
        // Set the attributes
        _streetAddress = streetAddress;
        _city = city;
        _provinceOrState = provinceOrState;
        _country = "USA";
    }

    public bool IsInUSA()
    {
        // Return if the country of the address is the USA
        return _country == "USA";
    }
    public string GetDisplay()
    {
        if (IsInUSA()) {
            string state = _provinceOrState;

            // Return the all of the values of the address formatted
            return $"{_streetAddress}\n{_city}, {state}";
        }
        else
        {
            string province = _provinceOrState;

            // Return the all of the values of the address formatted
            return $"{_streetAddress}\n{_city}, {province}\n{_country}";
        }
    }
}