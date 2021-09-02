using System;
using Contracts.Enums;

namespace TodosApp.Models
{
    public class GuidTodo
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Difficulty Difficulty { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsComplete { get; set; }
    }
}
