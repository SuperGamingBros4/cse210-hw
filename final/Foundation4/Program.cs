using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of activities
        List<Activity> activities = new List<Activity>();

        // Create a RunningActivity
        Activity runningActivity = new RunningActivity("24 Mar 2026", 45, 4);
        activities.Add(runningActivity);
        
        // Create a CyclingActivity
        Activity cyclingActivity = new CyclingActivity("12 Feb 2026", 30, 20);
        activities.Add(cyclingActivity);
        
        // Create a SwimmingActivity
        Activity swimmingActivity = new SwimmingActivity("16 Jun 2026", 60, 70);
        activities.Add(swimmingActivity);

        foreach (Activity activity in activities)
        {
            // Print a summary for each activity
            Console.WriteLine(activity.GetSummary());
        }
    }
}