public class Rectangle : Shape
{
    private double _width = 0;
    private double _length = 0;

    public Rectangle(string color, double width, double length) : base (color)
    {
        SetWidth(width);
        SetLength(length);
    }

    public override double GetArea()
    {
        double sideLengthX = GetWidth();
        double sideLengthY = GetLength();

        return sideLengthX * sideLengthY;
    }

    public double GetWidth()
    {
        return _width;
    }
    public void SetWidth(double width)
    {
        if (width > 0)
        {
            // Set width if it is greater than 0
            _width = width;
        }
        else
        {
            // Otherwise set width to 0
            _width = 0;
        }
    }
    public double GetLength()
    {
        return _length;
    }
    public void SetLength(double length)
    {
        if (length > 0)
        {
            // Set length if it is greater than 0
            _length = length;
        }
        else
        {
            // Otherwise set length to 0
            _length = 0;
        }
    }
}