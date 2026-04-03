public class Address
{
    private string _streetAddress;
    private string _city;
    private string _provinceOrState; // or state
    private string _country;

    public Address(string streetAddress, string city, string provinceOrState, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _provinceOrState = provinceOrState;
        _country = country;
    }

    public string GetStreetAddress()
    {
        return _streetAddress;
    }
    public string GetCity()
    {
        return _city;
    }
    public string GetProvince()
    {
        return _provinceOrState;
    }
    public string GetState()
    {
        return _provinceOrState;
    }
    public string GetCountry()
    {
        return _country;
    }

    public bool IsInUSA()
    {
        // Return if the country of the address is the USA
        return GetCountry() == "USA";
    }
    public string GetDisplay()
    {
        string streetAddress = GetStreetAddress();
        string city = GetCity();
        if (IsInUSA()) {
            string state = GetState();

            // Return the all of the values of the address formatted
            return $"{streetAddress}\n{city}, {state}";
        }
        else
        {
            string province = GetProvince();
            string country = GetCountry();

            // Return the all of the values of the address formatted
            return $"{streetAddress}\n{city}, {province}\n{country}";
        }
    }
}