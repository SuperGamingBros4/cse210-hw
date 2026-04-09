using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();

        // Test the Lecture class
        Event lecture = new Lecture("The Physical World",
                                    "Learn about the universe we inhabit and the forces that govern it.",
                                    new Address("107 Andrew Way", "Portland", "OR"),
                                    "4/15/2026", "9:00 A.M. to 12:15 P.M.",
                                    "Mary Sue", 300);
        events.Add(lecture);

        // Test the Reception class
        Event reception = new Reception("Brad Fathom Retirement",
                                        "Reception for the retirement of the head of the physics program.",
                                        new Address("120 Bremming Street", "Miami", "FL"),
                                        "5/1/2026", "11:00 A.M. to 3:00 P.M.",
                                        "signup@events.org");
        events.Add(reception);

        // Test the OutdoorGathering class
        Event outdoorGathering = new OutdoorGathering("Fourth of July Celebration",
                                                      "Town gathering for the Fourth of July at Shelby Park.",
                                                      new Address("Shelby Ave & S 20th St", "Nashville", "TN"),
                                                      "7/4/2026", "9:50 A.M. to 10:20 P.M.",
                                                      "Partially cloudy");
        events.Add(outdoorGathering);

        // Cannot use "event" as a name
        foreach (Event event1 in events)
        {
            // Display each of the detail options for each event
            Console.WriteLine("\nShort details:");
            Console.WriteLine(event1.GetShortDetails());
            Console.WriteLine("\nDetails:");
            Console.WriteLine(event1.GetDetails());
            Console.WriteLine("\nFull details:");
            Console.WriteLine(event1.GetFullDetails());
        }
    }
}