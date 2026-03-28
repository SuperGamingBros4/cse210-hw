using System;
using System.Collections.Generic;

/*
 *  Showing creativity and exceeding requirements:
 *   Added a daily goal, which is an eternal goal that gives 50% bonus for completing it each day.
 *   
 */

class Program
{
    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create new goal");
        Console.WriteLine("  2. List goals");
        Console.WriteLine("  3. Save goals");
        Console.WriteLine("  4. Load goals");
        Console.WriteLine("  5. Record event");
        Console.WriteLine("  6. Quit");
    }
    static void DisplayGoalTypes()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Daily Goal");
    }
    static void ListGoals(List<Goal> goals)
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            // Get the goal at `i` from the list
            Goal goal = goals[i];

            // Display the goal
            Console.Write($"  {i + 1}. ");
            Console.WriteLine(goal.GetDisplay());
        }
    }
    static string PromptFileName()
    {
        // Prompt for a file name
        Console.Write("What is the file name for the goal file? ");
        string filename = Console.ReadLine();

        return filename;
    }

    static void Main(string[] args)
    {
        // Create a list of the goals
        List<Goal> goals = new List<Goal>();

        int points = 0;

        bool running = true;
        while (running)
        {
            // Show how many points the user has
            Console.WriteLine($"\nYou have {points} points.\n");

            // Show the menu to the user
            DisplayMenu();

            // Prompt for a choice
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                // 1. Create new goal
                case "1":
                    DisplayGoalTypes();

                    // Prompt for the goal type
                    Console.Write("Which type of goal would you like to create? ");
                    string goalType = Console.ReadLine();

                    Goal newGoal = null;

                    switch (goalType)
                    {
                        // 1. Simple Goal
                        case "1":
                            newGoal = new SimpleGoal();
                            break;
                        // 2. Eternal Goal
                        case "2":
                            newGoal = new EternalGoal();
                            break;
                        // 3. Checklist Goal
                        case "3":
                            newGoal = new ChecklistGoal();
                            break;
                        case "4":
                            newGoal = new DailyGoal();
                            break;
                    }

                    // Exit if the goal was not assigned
                    if (newGoal == null)
                        break;

                    // Prompt for and set the goal attributes
                    newGoal.Prompt();

                    // Add the goal to the list of goals
                    goals.Add(newGoal);
                    break;
                // 2. List goals
                case "2":
                    ListGoals(goals);
                    break;
                // 3. Save goals
                case "3":
                    try
                    {
                        // Prompt for the save file
                        string saveFileName = PromptFileName();

                        // Create a StreamWriter for the file
                        StreamWriter writer = new StreamWriter(saveFileName);

                        // Write the points to the top of the file
                        writer.WriteLine(points);

                        // Save each goal to the file
                        foreach (Goal goal in goals)
                        {
                            // Write the goal type to the file
                            writer.Write($"{goal.GetGoalType()},");

                            // Write the serialized data to the file
                            writer.WriteLine(goal.Serialize());
                        }

                        // Close the file
                        writer.Close();
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File not found...");
                    }
                    break;
                // 4. Load goals
                case "4":
                    try
                    {
                        // Prompt for the load file
                        string loadFileName = PromptFileName();

                        // Create a CSVReader for the file
                        CSVReader reader = new CSVReader(loadFileName);

                        // Read the points from the top of the file
                        points = int.Parse(reader.ReadRow()[0]);

                        // Clear the current goals
                        goals.Clear();

                        // Read each goal from the file
                        while (true)
                        {
                            // Read the current line from the file
                            List<string> rowValues = reader.ReadRow();

                            // Stop if the line is empty
                            if (rowValues == null)
                                break;

                            // Determine which goal it is
                            switch (rowValues[0])
                            {
                                case "SimpleGoal":
                                    goals.Add(new SimpleGoal(rowValues));
                                    break;
                                case "EternalGoal":
                                    goals.Add(new EternalGoal(rowValues));
                                    break;
                                case "ChecklistGoal":
                                    goals.Add(new ChecklistGoal(rowValues));
                                    break;
                                case "DailyGoal":
                                    goals.Add(new DailyGoal(rowValues));
                                    break;
                            }
                        }

                        // Close the file
                        reader.Close();
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File not found...");
                    }
                    break;
                // 5. Record event
                case "5":
                    // List the goals
                    ListGoals(goals);

                    // Prompt for the goal to complete
                    Console.Write("Which goal did you accomplish? ");
                    int completedGoalIndex = int.Parse(Console.ReadLine()) - 1;

                    // Exit if the index is invalid
                    if (completedGoalIndex > goals.Count - 1 || completedGoalIndex < 0)
                        break;

                    // Get the goal from the list
                    Goal completedGoal = goals[completedGoalIndex];

                    if (!completedGoal.IsComplete())
                    {
                        // Complete the goal
                        completedGoal.Complete();

                        // Get the points earned
                        int earnedPoints = completedGoal.GetPoints();

                        // Display a congratulating message
                        Console.WriteLine($"Congratulations! You have earned {earnedPoints} points.");

                        // Add the earned points to the total
                        points += earnedPoints;
                    }
                    break;
                // 6. Quit
                case "6":
                    running = false;
                    break;
            }
        }
    }
}