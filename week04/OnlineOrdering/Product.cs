public class Product
{
    private string _name;
    private string _productID;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productID, string price, int quantity)
    {
        _name = name;
        _productID = productID;
        _price = decimal.Parse(price);
        _quantity = quantity;
    }

    public decimal GetCost()
    {
        return _price * _quantity;
    }

    public string LabelInfo()
    {
        return $"{_productID} {_name} x{_quantity}";
    }
}