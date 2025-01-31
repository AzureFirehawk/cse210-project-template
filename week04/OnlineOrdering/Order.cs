public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void GetTotalCost()
    {
        decimal totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.GetCost();
        }
        if (_customer.IsUSA())
        {
            totalCost += 5;
        }
        else
        {
            totalCost += 35;
        }
        Console.WriteLine($"Total cost: ${totalCost}");
    }

    public void PackingLabel()
    {
        foreach (Product product in _products)
        {
            Console.WriteLine(product.LabelInfo());
        }
    }

    public void ShippingLabel()
    {
        Console.WriteLine(_customer.GetInfo());
    }
}