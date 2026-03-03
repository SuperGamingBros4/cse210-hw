using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Michaelsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 1995;
        job1._endYear = 2004;

        Job job2 = new Job();
        job2._company = "Pear";
        job2._jobTitle = "Project Manager";
        job2._startYear = 2004;
        job2._endYear = 2010;

        Resume resume = new Resume();
        resume._name = "David Brickham";

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}