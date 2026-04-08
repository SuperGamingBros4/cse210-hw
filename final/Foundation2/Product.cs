public class Product
{
    private int _id;
    private string _name;
    private double _pricePerUnit;
    private int _quantity;

    public Product(int id, string name, double pricePerUnit, int quantity)
    {
        // Set the values of the product
        _id = id;
        _name = name;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public string GetDisplay()
    {
        return $"ID: {_id}, {_name}";
    }
    public double GetTotalCost()
    {
        // Return the price per unit times the quantity
        return _pricePerUnit * _quantity;
    }
}