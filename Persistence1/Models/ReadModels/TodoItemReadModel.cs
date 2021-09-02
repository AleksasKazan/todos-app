using System;
using System.ComponentModel;
using Contracts.Enums;

namespace Persistence.Models.ReadModels
{
    public class TodoItemReadModel
    {
        //public Guid Id { get; set; }
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Difficulty Difficulty { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsComplete { get; set; }
    }
}
