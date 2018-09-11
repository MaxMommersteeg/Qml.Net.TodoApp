using System;

namespace TodoApp.Core.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public bool IsOpen()
        {
            return ClosedAt == null;
        }

        public bool IsClosed()
        {
            return ClosedAt != null;
        }

        public void Open()
        {
            ClosedAt = null;
        }

        public void Close()
        {
            ClosedAt = DateTime.UtcNow;
        }
    }
}
