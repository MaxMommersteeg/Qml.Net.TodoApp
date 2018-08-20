using System;

namespace TodoApp.FrontEnd.Model
{
    public class TodoItemModel
    {
        public TodoItemModel(int id, string title, DateTime createdAt, DateTime? completedAt = null)
        {
            Id = id;
            Title = title;
            CreatedAt = createdAt;
            CompletedAt = completedAt;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? CompletedAt { get; private set; }
    }
}
