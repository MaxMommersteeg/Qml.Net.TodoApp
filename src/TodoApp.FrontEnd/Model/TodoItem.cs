using System;

namespace TodoApp.Model
{
    public class TodoItem
    {
        public TodoItem(string title)
        {
            Title = title;
            Created = DateTime.UtcNow;
        }

        public string Title { get; private set; }

        public DateTime Created { get; private set; }

        public bool IsCompleted { get; set; }

        public DateTime? Completed { get; private set; }
    }
}
