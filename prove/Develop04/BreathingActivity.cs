using System;
using System.Threading;

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
    static private void BreatheInMessage(int duration)
    {
        // Show breathe in message
        WriteOverDuration("Breathe in...", (double)duration / 4);

        // Pause for the duration with a countdown
        PauseWithCountdown(3 * duration / 4);
    }
    static private void BreatheOutMessage(int duration)
    {
        // Show breathe out message
        WriteOverDuration("Now breathe out...", (double)duration / 4);

        // Pause for the duration with a countdown
        PauseWithCountdown(3 * duration / 4);
    }
    static private void WriteOverDuration(string str, double duration)
    {
        // Write a message to the console over the specified duration

        // The starting timestamp
        DateTime startTime = DateTime.Now;

        // The remaining duration (in ms) for the string to be written out
        double durationMS = duration * 1000;

        // The amount of time (in ms) per character to wait for
        int msDelay = (int)(durationMS / str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            // Write the current character out
            Console.Write(str[i]);

            // The amount of elapsed time (in ms)
            double elapsedMs = DateTime.Now.Subtract(startTime).TotalMilliseconds;

            // If the amount of time passed is less than the expected time for the
            // current character, then sleep
            if (elapsedMs < msDelay*(i+1))
            {
                // Sleep for the specified time
                Thread.Sleep(msDelay);
            }
        }
    }
}