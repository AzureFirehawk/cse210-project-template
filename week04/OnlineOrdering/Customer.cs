public class Customer
{
    private string _name;
    private Address _address;

    // If address is separately created
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // If all information is provided at once
    public Customer(string name, string streetAddress, string city, string state, string country)
    {
        _name = name;
        _address = new Address(streetAddress, city, state, country);
    }

    // Accommodate address line 2
    public Customer(string name, string streetAddress, string addressLine2, string city, string state, string country)
    {
        _name = name;
        _address = new Address(streetAddress, addressLine2, city, state, country);
    }

    public string GetInfo()
    {
        return $"{_name}\n{_address.AddressString()}";
    }

    public bool IsUSA()
    {
        return _address.IsUSA();
    }
}