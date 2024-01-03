namespace PersonalTaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            taskManager.LoadTasksFromFile();

            while (true)
            {
                Console.WriteLine("\nAvailable commands: add, list, update, delete, exit");
                Console.Write("Enter command: ");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "add":
                        AddTask(taskManager);
                        break;
                    case "list":
                        ListTasks(taskManager);
                        break;
                    case "update":
                        UpdateTask(taskManager);
                        break;
                    case "delete":
                        DeleteTask(taskManager);
                        break;
                    case "exit":
                        taskManager.SaveTasksToFile();
                        return;
                    default:
                        Console.WriteLine("Unknown command. Please try again.");
                        break;
                }
            }
        }

        static void AddTask(TaskManager taskManager)
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();

            Console.Write("Enter task description: ");
            string description = Console.ReadLine();

            Console.Write("Enter due date (yyyy-mm-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter task priority: ");
            string priority = Console.ReadLine();

            Task newTask = new Task
            {
                Id = taskManager.GetAllTasks().Count + 1,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = priority
            };
            taskManager.AddTask(newTask);
        }

        static void ListTasks(TaskManager taskManager)
        {
            var tasks = taskManager.GetAllTasks();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Due: {task.DueDate.ToShortDateString()}, Priority: {task.Priority}");
            }
        }

        static void UpdateTask(TaskManager taskManager)
        {

        }

        static void DeleteTask(TaskManager taskManager)
        {

        }
    }
}
