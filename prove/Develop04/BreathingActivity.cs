using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    )
    {

    }

    public void Start()
    {
        // Display the start message
        ShowStartMessage();

        // Set the breathe in and out durations
        int breatheInDuration = 3;
        int breatheOutDuration = 4;

        // Start the timer
        StartTimer();

        // Keep running until the activity is over
        while (!DurationElapsed())
        {
            // Separate the breathing messages with a newline
            Console.WriteLine();

            // Display the breathe in message
            BreatheInMessage(breatheInDuration);
            // Display the breath out message
            BreatheOutMessage(breatheOutDuration);

            if (breatheInDuration < 4)
            {
                breatheInDuration++;
            }
            if (breatheOutDuration < 6)
            {
                breatheOutDuration += 2;
            }
        }

        // Display the finish message
        Finish();
    }
    private void BreatheInMessage(int duration)
    {
        // Show breathe in message
        Console.Write("Breath in...");

        // Pause for the duration with a countdown
        PauseWithCountdown(duration);
    }
    private void BreatheOutMessage(int duration)
    {
        // Show breathe out message
        Console.Write("Now breathe out...");

        // Pause for the duration with a countdown
        PauseWithCountdown(duration);
    }
}