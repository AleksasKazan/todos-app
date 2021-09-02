using System;
using Contracts.Enums;

namespace Persistence.Models
{
    public class TodoItem
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Difficulty Difficulty { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsComplete { get; set; }
    }
}
