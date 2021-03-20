using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models {
    public class TodoItem {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTimeOffset?DueAt { get; set; }
    }
}