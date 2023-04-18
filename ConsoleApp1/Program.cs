using System;

class Program
{
    static void Main(string[] args)
    {
        // Create some jobs
        Job job1 = new Job(1, 1, 10, 5);
        Job job2 = new Job(2, 1, 5, 7);
        Job job3 = new Job(3, 2, 3, 3);
        Job job4 = new Job(4, 20, 30, 9);
        Job job5 = new Job(5, 9, 2, 1);

        // Create a job collection
        JobCollection collection = new JobCollection(5);

        // Add the jobs to the collection
        collection.Add(job1);
        collection.Add(job2);
        collection.Add(job3);
        collection.Add(job4);
        collection.Add(job5);
        collection.Remove(5);
        collection.Find(2);


        // Create a scheduler and pass in the job collection
        Scheduler scheduler = new Scheduler(collection);

        // Test the scheduler's sorting methods
        Console.WriteLine("FirstComeFirstServed:");
        foreach (Job job in scheduler.FirstComeFirstServed())
        { 
            
            Console.WriteLine(job);
        }

        Console.WriteLine("Priority:");
        foreach (Job job in scheduler.Priority())
        {
            
            Console.WriteLine(job);
        }

        Console.WriteLine("ShortestJobFirst:");
        foreach (Job job in scheduler.ShortestJobFirst())
        {
            
            Console.WriteLine(job);
        }
    }
}
