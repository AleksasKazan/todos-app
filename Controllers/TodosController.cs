using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models;
using TodosApp.Models.ResponseModels;
using Persistence;
using Persistence.Models.ReadModels;

namespace TodosApp.Controllers
{
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodosRepository _todosRepository;
        public TodosController(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        [HttpGet]
        [Route("todos")]
        public Task<IEnumerable<TodoItemReadModel>> GetTodos()
        {
            return _todosRepository.GetAll();
        }

        [HttpGet]
        [Route("todos/{Id}")]
        public ActionResult<TodoItem> GetTodo(string Id)
        {
            var todoItem = _todosRepository.Get(Id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost]
        [Route("todos")]
        public ActionResult<TodoItem> SaveOrUpdate([FromBody] TodoItem request)
        {
            var alreadyExist = _todosRepository.GetAll().Result;

            var todoItem = new TodoItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Description = request.Description,
                Difficulty = request.Difficulty,
                DateCreated = request.DateCreated,
                IsComplete = request.IsComplete
            };

            foreach (var item in alreadyExist)
            {
                if (item.Id == request.Id)
                {
                    todoItem = new TodoItem
                    {
                        Id = request.Id,
                        Title = request.Title,
                        Description = request.Description,
                        Difficulty = request.Difficulty,
                        DateCreated = request.DateCreated,
                        IsComplete = request.IsComplete
                    };
                }
            }
            _todosRepository.SaveOrUpdate(todoItem);

            return CreatedAtAction("GetTodo", new { Id = todoItem.Id }, todoItem.MapToTodoItemResponse());
        }

        [HttpDelete]
        [Route("todos/{Id}")]
        public IActionResult DeleteTodo(string Id)
        {
            var todoToDelete = _todosRepository.Get(Id);

            if (todoToDelete is null)
            {
                return NotFound();
            }
            _todosRepository.Delete(Id);

            return NoContent();
        }
    }
}