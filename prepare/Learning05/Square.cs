public class Square : Shape
{
    private double _length = 0;

    public Square(string color, double sideLength) : base(color)
    {
        SetLength(sideLength);
    }

    public override double GetArea()
    {
        double sideLength = GetLength();
        
        return sideLength * sideLength;
    }
    public double GetLength()
    {
        return _length;
    }
    public void SetLength(double sideLength)
    {
        if (sideLength > 0)
        {
            // Set side length if it is greater than 0
            _length = sideLength;
        }
        else
        {
            // Otherwise set side length to 0
            _length = 0;
        }
    }
}