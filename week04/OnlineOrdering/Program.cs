using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // Random Addresses
        Address address1 = new Address("33 Portland Drive", "Frontenac", "MO", "USA");
        Address address2 = new Address("70451 Nader Pass", "Apt. 322", "Tromphaven", "AB", "Canada");
        Address address3 = new Address("900 Osinski Course", "Fisherhaven", "VT", "Great Britain");

        // Create Customers
        Customer customer1 = new Customer("Mary Michaels", address1);
        Customer customer2 = new Customer("Joseph Johnson", address2);
        Customer customer3 = new Customer("Samantha Smith", address3);

        // Create Products
        Product product1 = new Product("Widget", "1234", "5.99", 4);
        Product product2 = new Product("Gizmo", "5678", "9.99", 5);
        Product product3 = new Product("Thingy", "9012", "4.99", 13);
        Product product4 = new Product("Gadget", "3456", "2.99", 15);
        Product product5 = new Product("Something", "1234", "9.99", 7);

        // Create Orders
        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);
        Order order3 = new Order(customer3);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        order2.AddProduct(product4);
        order2.AddProduct(product3);

        order3.AddProduct(product5);
        order3.AddProduct(product3);
        order3.AddProduct(product2);
        order3.AddProduct(product4);

        // Print Labels and costs
        order1.ShippingLabel();
        order1.PackingLabel();        
        order1.GetTotalCost();

        Console.WriteLine("\n");
        order2.ShippingLabel();        
        order2.PackingLabel();        
        order2.GetTotalCost();

        Console.WriteLine("\n");
        order3.ShippingLabel();        
        order3.PackingLabel();        
        order3.GetTotalCost();
    }
}