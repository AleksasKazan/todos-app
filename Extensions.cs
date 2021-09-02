using System;
using Persistence.Models;
using TodosApp.Models.ResponseModels;

namespace TodosApp
{
    public static class Extensions
    {
        public static TodoItemResponse MapToTodoItemResponse(this TodoItem todoItem)
        {
            return new TodoItemResponse
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                Difficulty = todoItem.Difficulty,
                DateCreated = todoItem.DateCreated,
                IsComplete = todoItem.IsComplete
            };
        }
    }
}
