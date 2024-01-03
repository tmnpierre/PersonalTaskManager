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
                Console.Clear();
                ShowMenu();

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
                    case "search":
                        SearchTasks(taskManager);
                        break;
                    case "exit":
                        taskManager.SaveTasksToFile();
                        return;
                    default:
                        Console.WriteLine("Unknown command. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Personal Task Manager");
            Console.WriteLine("=====================");
            Console.WriteLine("Commands:");
            Console.WriteLine("  add    - Add a new task");
            Console.WriteLine("  edit   - Edit an existing task");
            Console.WriteLine("  delete - Delete a task");
            Console.WriteLine("  list   - List all tasks");
            Console.WriteLine("  search - Search tasks");
            Console.WriteLine("  exit   - Exit the application");
            Console.WriteLine();
        }

        static void AddTask(TaskManager taskManager)
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();

            Console.Write("Enter task description: ");
            string description = Console.ReadLine();

            Console.Write("Enter due date (yyyy-mm-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            string priority = ChoosePriority();

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

            Console.Write("Enter new priority (Low, Medium, High, blank to skip): ");
            string priorityInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(priorityInput))
            {
                task.Priority = ChoosePriority();
            }

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

        static void SearchTasks(TaskManager taskManager)
        {
            Console.Write("Enter keyword (or leave blank for no keyword): ");
            string keyword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(keyword))
                keyword = null;

            Console.Write("Enter date (yyyy-mm-dd, or leave blank for no date): ");
            string dateString = Console.ReadLine();
            DateTime? date = null;
            if (!string.IsNullOrWhiteSpace(dateString))
                date = DateTime.Parse(dateString);

            var result = taskManager.SearchTasks(keyword, date);
            if (result.Count == 0)
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in result)
            {
                Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Due: {task.DueDate.ToShortDateString()}, Priority: {task.Priority}");
            }
        }

        static string ChoosePriority()
        {
            string priority = "";
            while (priority != "Low" && priority != "Medium" && priority != "High")
            {
                Console.WriteLine("Choose priority (Low, Medium, High):");
                priority = Console.ReadLine();
                switch (priority.ToLower())
                {
                    case "low":
                        priority = "Low";
                        break;
                    case "medium":
                        priority = "Medium";
                        break;
                    case "high":
                        priority = "High";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter Low, Medium, or High.");
                        break;
                }
            }
            return priority;
        }
    }
}