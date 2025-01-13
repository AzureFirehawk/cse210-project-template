using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        Job job2 = new Job();

        job1._company = "Apple";
        job1._jobTitle = "Software Developer";
        job1._startYear = 2016;
        job1._endYear = 2023;

        job2._jobTitle = "Grand Poobah";
        job2._company = "Some Such Place";
        job2._endYear = 2025;
        job2._startYear = 2014;

        Resume resume = new Resume();
        resume._name = "Some Person Here";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.ShowResume();
    }
}