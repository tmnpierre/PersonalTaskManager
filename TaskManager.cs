using System.Text.Json;

namespace PersonalTaskManager
{
    internal class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private readonly string filePath = "tasks.json";

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public List<Task> GetAllTasks()
        {
            return tasks;
        }

        public void UpdateTask(int taskId, Task updatedTask)
        {
            var task = tasks.Find(t => t.Id == taskId);
            if (task != null)
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.DueDate = updatedTask.DueDate;
                task.Priority = updatedTask.Priority;
            }
        }

        public void DeleteTask(int taskId)
        {
            tasks.RemoveAll(t => t.Id == taskId);
        }

        public void SaveTasksToFile()
        {
            var jsonString = JsonSerializer.Serialize(tasks);
            File.WriteAllText(filePath, jsonString);
        }

        public void LoadTasksFromFile()
        {
            if (File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                tasks = JsonSerializer.Deserialize<List<Task>>(jsonString) ?? new List<Task>();
            }
        }

        public List<Task> SearchTasks(string keyword, DateTime? date)
        {
            return tasks.Where(task =>
                (keyword == null || task.Title.Contains(keyword) || task.Description.Contains(keyword)) &&
                (date == null || task.DueDate.Date == date.Value.Date)).ToList();
        }
    }
}
