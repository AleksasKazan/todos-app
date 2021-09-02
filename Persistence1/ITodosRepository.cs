using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Enums;
using Persistence.Models;
using Persistence.Models.ReadModels;

namespace Persistence
{
    public interface ITodosRepository
    {
        Task<IEnumerable<TodoItemReadModel>> GetAll();

        Task<TodoItemReadModel> Get(string id);

        Task<int> SaveOrUpdate(TodoItem todoItem);

        Task<int> Delete(string id);
    }
}
