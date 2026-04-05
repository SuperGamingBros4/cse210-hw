using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a USA Customer
        Customer customerUSA = new Customer("Lisa Simpson", new Address("472 Evergreen Terrace", "Springfield", "OR", "USA"));

        // Create an Order
        Order order1 = new Order(customerUSA);
        // Add some products
        order1.AddProduct(new Product(25, "AA Battery 12-Pack", 2.49, 5));
        order1.AddProduct(new Product(4, "A1 Paper 300 Count", 9.99, 3));
        order1.AddProduct(new Product(23, "Staples 50x4 Pack", 4.49, 5));

        Console.WriteLine("Order 1:");
        Console.WriteLine($"Price: ${order1.GetTotalCost()}");
        Console.WriteLine("Packing label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        // Create a non USA customer
        Customer customerNonUSA = new Customer("Terrance Williams", new Address("73 Bristol Street", "London", "NW1 6XE", "UK"));

        // Create a second Order
        Order order2 = new Order(customerNonUSA);
        // Add some products
        order2.AddProduct(new Product(4, "A1 Paper 300 Count", 9.99, 10));
        order2.AddProduct(new Product(23, "Staples 50x4 Pack", 4.49, 2));

        Console.WriteLine("Order 2:");
        Console.WriteLine($"Price: ${order2.GetTotalCost()}");
        Console.WriteLine("Packing label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
    }
}