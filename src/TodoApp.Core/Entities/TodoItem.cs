using System;

namespace TodoApp.Core.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedAt { get; set; }

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkCompleted()
        {
            CompletedAt = DateTime.UtcNow;
        }
    }
}
