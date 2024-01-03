namespace PersonalTaskManager
{
    internal class TaskManager
    {
        private List<Task> tasks = new List<Task>();

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
    }
}
