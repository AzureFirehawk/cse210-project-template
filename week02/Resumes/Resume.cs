public class Resume
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    public void ShowResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        foreach (Job item in _jobs)
        {  
            item.DisplayJob();
        }
    }
}