public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }
    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
    }
    public double GetProductsCost()
    {
        double total = 0;

        // Add the price of each product in the order
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        return total;
    }
    public double GetShippingCost()
    {
        if (_customer.IsInUSA())
        {
            // $5 shipping cost if in the USA
            return 5.0;
        }
        else
        {
            // $35 shipping cost outside the USA
            return 35.0;
        }
    }
    public double GetTotalCost()
    {
        return GetShippingCost() + GetProductsCost();
    }
    public string GetPackingLabel()
    {
        string packingLabel = "";

        // Add the product id and name for each product in the order
        for (int i = 0; i < _products.Count; i++)
        {
            // Get the current product from the list
            Product product = _products[i];

            // Add the item to the packing label
            packingLabel += product.GetDisplay();

            // Add a newline if this is not the final product in the order
            if (i != _products.Count - 1)
            {
                packingLabel += '\n';
            }
        }

        return packingLabel;
    }
    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}