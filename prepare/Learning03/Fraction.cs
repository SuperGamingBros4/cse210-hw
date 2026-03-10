public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        // The most simplified fraction for a whole number is
        //
        //    x
        //   ---
        //    1
        //

        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and Setters
    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int top)
    {
        _top = top;
    }
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int bottom)
    {
        // Bottom cannot equal zero because that would mean dividing by zero.
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            _bottom = 1;
        }
    }

    public string GetFractionString()
    {
        // Return a string in the form "x/y"
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        // Divide the top by the bottom and return the decimal
        return (double)_top / _bottom;
    }
}