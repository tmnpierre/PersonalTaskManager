namespace PersonalTaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            taskManager.LoadTasksFromFile();

            taskManager.AddTask(new Task { Id = 1, Title = "Learn C#", Description = "Study the basics of C#", DueDate = DateTime.Now.AddDays(7), Priority = "High" });
            taskManager.AddTask(new Task { Id = 2, Title = "Complete Project", Description = "Finish the personal task manager project", DueDate = DateTime.Now.AddDays(14), Priority = "Medium" });

            var tasks = taskManager.GetAllTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task: {task.Title}, Due: {task.DueDate.ToShortDateString()}, Priority: {task.Priority}");
            }

            taskManager.SaveTasksToFile();
        }
    }
}
