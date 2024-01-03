namespace PersonalTaskManager
{
    internal class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }

        public Task() { }

        public Task(int id, string title, string description, DateTime dueDate, string priority)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }
    }
}
