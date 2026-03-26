public abstract class Goal
{
    protected string _name = "";
    protected string _description = "";
    protected int _points = 0;

    public Goal()
    {
        Prompt();
    }

    protected virtual void Prompt()
    {
        // Prompt for the name of the goal
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        // Prompt for the description of the goal
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        // Prompt for the points the goal is worth
        Console.Write("What is the amounts of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        // Set the class attributes
        _name = name;
        _description = description;
        SetPoints(points);
    }
    protected void SetPoints(int points)
    {
        if (points > 0)
        {
            _points = points;
        }
        else
        {
            _points = 0;
        }
    }
    public virtual int GetPoints()
    {
        return _points;
    }
    public virtual string GetDisplay()
    {
        char completedChar = ' ';
        
        // Display an X if the goal is completed
        if (IsComplete())
            completedChar = 'X';

        return $"[{completedChar}] {_name} ({_description})";
    }

    public abstract bool IsComplete();
    public abstract void Complete();
}