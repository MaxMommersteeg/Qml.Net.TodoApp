﻿using System;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Data
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }
    }
}
