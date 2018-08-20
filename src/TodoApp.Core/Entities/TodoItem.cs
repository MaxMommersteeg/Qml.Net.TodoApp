using System;

namespace TodoApp.Core.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }
    }
}
