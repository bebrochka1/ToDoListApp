class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, State> taskList = new Dictionary<string, State>();
        string option = "";

        while (option != "e")
        {
            Console.Clear();
            Console.WriteLine("ToDoList program");
            Console.WriteLine("Enter h - to see manual");
            Console.WriteLine("\nTasks: ");
            
            Console.WriteLine("\nNot Started: ");
            taskList.Where((n) => n.Value == State.NotStarted).ToList().ForEach((n) =>
            {
                Console.WriteLine(n.Key);
            });

            Console.WriteLine("\nIn progress: ");
            taskList.Where((n) => n.Value == State.InProgress).ToList().ForEach((n) =>
            {
                Console.WriteLine(n.Key);
            });

            Console.WriteLine("\nFinished: ");
            taskList.Where((n) => n.Value == State.Finished).ToList().ForEach((n) =>
            {
                Console.WriteLine(n.Key);
            });


            switch (option)
            {
                case "h":
                    Console.Clear();
                    Console.WriteLine("1 - Add new task\n2 - Move existing task to \"In Progress\"\n3 - Move existing task to \"Finished\"\n4 - Clear tasks");
                    if(Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        break;
                        
                    }
                    continue;

                case "1":
                    Console.Clear();
                    Console.WriteLine("Enter description about new Task");
                    string task = Console.ReadLine();
                    taskList.Add(task, State.NotStarted);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Which task is in progress?");
                    int taskNumber = int.Parse(Console.ReadLine())-1;
                    var keys = taskList.Keys.ToList();
                    string taskKey = keys[taskNumber];
                    taskList[taskKey] = State.InProgress;
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Which task you finished?");
                    taskNumber = int.Parse(Console.ReadLine()) - 1;
                    keys = taskList.Keys.ToList();
                    taskKey = keys[taskNumber];
                    taskList[taskKey] = State.Finished;
                    break;

                case "4":
                    taskList.Clear();
                    break;


            }
            option = Console.ReadLine();
        }
    }
}

public static class DictionaryExtensions
{
    public static void ForEach<K, V>(this Dictionary<K, V> source, Action<K, V> action)
    {
        foreach (var item in source)
        {
            action(item.Key, item.Value);
        }
    }
}

enum State
{
    NotStarted,
    InProgress,
    Finished
}