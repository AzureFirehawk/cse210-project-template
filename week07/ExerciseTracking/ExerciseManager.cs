public class ExerciseManager
{
    private List<Exercise> _exercises = new List<Exercise>();
    private string _fileName = "exercises.csv";
    private int _runTotalTime;
    private double _runTotalDistance;
    private int _bikeTotalTime;
    private double _bikeTotalDistance;
    private int _swimTotalTime;
    private double _swimTotalDistance;

    public ExerciseManager() { }

    public void Start()
    {
        while (true)
        {
            _runTotalTime = 0;
            _runTotalDistance = 0.0;
            _bikeTotalTime = 0;
            _bikeTotalDistance = 0.0;
            _swimTotalTime = 0;
            _swimTotalDistance = 0.0;
            Console.Write("Menu Options:\n  1. Run\n  2. Swim\n  3. Bike\n  4. List Exercises\n  5. Save Exercises\n  6. Load Exercises\n  7. See Totals\n  8. Quit\nSelect a choice from the menu: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Write("How many minutes did you run? ");
                int minutes = int.Parse(Console.ReadLine());
                Console.Write("How far did you run? ");
                int distance = int.Parse(Console.ReadLine());
                Running run = new Running(minutes, distance);
                AddExercise(run);
            }
            else if (choice == "2")
            {
                Console.Write("How many minutes did you swim? ");
                int minutes = int.Parse(Console.ReadLine());
                Console.Write("How many laps did you swim? ");
                int laps = int.Parse(Console.ReadLine());
                Swimming swim = new Swimming(minutes, laps);
                AddExercise(swim);
            }
            else if (choice == "3")
            {
                Console.Write("How many minutes did you bike? ");
                int minutes = int.Parse(Console.ReadLine());
                Console.Write("What was your average speed? ");
                int speed = int.Parse(Console.ReadLine());
                Bicycles bike = new Bicycles(minutes, speed);
                AddExercise(bike);
            }
            else if (choice == "4")
            {
                foreach (Exercise exercise in _exercises)
                {
                    Console.WriteLine(exercise.GetSummary());
                }
            }
            else if (choice == "5")
            {
                SaveExercises();
            }
            else if (choice == "6")
            {
                LoadExercises();
            }
            else if (choice == "7")
            {
                CalculateTotals();
                Console.WriteLine($"You ran {_runTotalTime} minutes for a total of {_runTotalDistance} miles.");
                Console.WriteLine($"You swam {_swimTotalTime} minutes for a total of {_swimTotalDistance} miles.");
                Console.WriteLine($"You cycled {_bikeTotalTime} minutes for a total of {_bikeTotalDistance} miles.");
            }
            else if (choice == "8")
            {
                break;
            }
        }
    }

    private void AddExercise(Exercise exercise)
    {
        _exercises.Add(exercise);
    }

    private void SaveExercises()
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            foreach (Exercise exercise in _exercises)
            {
                outputFile.WriteLine(exercise.GetSaveSummary());
            }
        }
    }

    private void LoadExercises()
    {
        _exercises.Clear();
        string[] lines = File.ReadAllLines(_fileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split("š");
            string type = parts[1].Trim();
            if (type == "Running")
            {
                Running run = new Running(int.Parse(parts[2].Trim()), double.Parse(parts[3].Trim()));
                AddExercise(run);
            }
            else if (type == "Swimming")
            {
                Swimming swim = new Swimming(int.Parse(parts[2].Trim()), int.Parse(parts[3].Trim()));
                AddExercise(swim);
            }
            else if (type == "Bicycles")
            {
                Bicycles bike = new Bicycles(int.Parse(parts[2].Trim()), int.Parse(parts[4].Trim()));
            }
        }
    }

    private void CalculateTotals()
    {
        foreach (Exercise exercise in _exercises)
        {
            string type = exercise.GetSaveSummary().Split("š")[1].Trim();
            if (type == "Running")
            {
                _runTotalTime += int.Parse(exercise.GetSaveSummary().Split("š")[2].Trim());
                _runTotalDistance += exercise.GetDistance();
            }
            else if (type == "Swimming")
            {
                _swimTotalTime += int.Parse(exercise.GetSaveSummary().Split("š")[2].Trim());
                _swimTotalDistance += exercise.GetDistance();
            }
            else if (type == "Bicycles")
            {
                _bikeTotalTime += int.Parse(exercise.GetSaveSummary().Split("š")[2].Trim());
                _bikeTotalDistance += exercise.GetDistance();
            }
        }
    }
}