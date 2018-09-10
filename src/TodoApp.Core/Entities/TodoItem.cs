using System;

namespace TodoApp.Core.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public bool IsCompleted()
        {
            return CompletedAt != null;
        }

        public void MarkCompleted()
        {
            CompletedAt = DateTime.UtcNow;
        }
    }
}
