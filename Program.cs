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
                Console.WriteLine("\nAvailable commands: add, edit, delete, list, exit");
                Console.Write("Enter command: ");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "add":
                        AddTask(taskManager);
                        break;
                    case "edit":
                        UpdateTask(taskManager);
                        break;
                    case "delete":
                        DeleteTask(taskManager);
                        break;
                    case "list":
                        ListTasks(taskManager);
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

        static void UpdateTask(TaskManager taskManager)
        {
            Console.Write("Enter task ID to update: ");
            int taskId = int.Parse(Console.ReadLine());

            var task = taskManager.GetAllTasks().Find(t => t.Id == taskId);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.Write("Enter new title (blank to skip): ");
            string title = Console.ReadLine();
            if (!string.IsNullOrEmpty(title))
                task.Title = title;

            Console.Write("Enter new description (blank to skip): ");
            string description = Console.ReadLine();
            if (!string.IsNullOrEmpty(description))
                task.Description = description;

            Console.Write("Enter new due date (yyyy-mm-dd, blank to skip): ");
            string dueDateString = Console.ReadLine();
            if (!string.IsNullOrEmpty(dueDateString))
                task.DueDate = DateTime.Parse(dueDateString);

            Console.Write("Enter new priority (blank to skip): ");
            string priority = Console.ReadLine();
            if (!string.IsNullOrEmpty(priority))
                task.Priority = priority;

            taskManager.UpdateTask(taskId, task);
        }

        static void DeleteTask(TaskManager taskManager)
        {
            Console.Write("Enter task ID to delete: ");
            int taskId = int.Parse(Console.ReadLine());

            taskManager.DeleteTask(taskId);
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
    }
}
