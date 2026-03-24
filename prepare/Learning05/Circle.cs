public class Circle : Shape
{
    private double _radius = 0;

    public Circle(string color, double radius) : base(color)
    {
        SetRadius(radius);
    }

    public override double GetArea()
    {
        double radius = GetRadius();
        
        return radius * radius * Math.PI;
    }

    public double GetRadius()
    {
        return _radius;
    }
    public void SetRadius(double radius)
    {
        if (radius > 0)
        {
            // Set radius if it is greater than 0
            _radius = radius;
        }
        else
        {
            // Otherwise set radius to 0
            _radius = 0;
        }
    }
}