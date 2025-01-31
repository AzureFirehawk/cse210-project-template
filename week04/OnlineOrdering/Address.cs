public class Address
{
    private string _streetAddress;
    private string _addressLine2; // Appartment number, etc.
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _addressLine2 = "";
        _city = city;
        _state = state;
        _country = country;
    }
    public Address(string streetAddress, string addressLine2, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _addressLine2 = addressLine2;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsUSA()
    {
        if (_country.ToUpper() == "USA")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string AddressString()
    {
        if (_addressLine2 != "")
        {
            return $"{_streetAddress}\n{_addressLine2}\n{_city}, {_state}, {_country}"; 
        }
        else
        {
            return $"{_streetAddress}\n{_city}, {_state}, {_country}"; 
        }
    }
}