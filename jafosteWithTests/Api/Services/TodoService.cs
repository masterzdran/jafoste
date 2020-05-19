using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Abstractions;

namespace API.Services
{
    public sealed class TodoService : ITodoService
    {
        private readonly IRepository<TodoItem> _repository;


        public TodoService(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            var r = await _repository.Get(orderBy: c => c.OrderBy(n => n.Id));
            return r.ToList();
        }

        public async Task<TodoItem> GetTodoItem(long id)
        {
           var todoItem = await _repository.Get(filter: c => c.Id == id);
           return todoItem.FirstOrDefault();
        }

        public void PutTodoItem(long id, TodoItem todoItem)
        {
            _repository.UpdateEntity(todoItem);
            _repository.Save();
        }

        public void PostTodoItem(TodoItem todoItem)
        {
            _repository.InsertEntity(todoItem);
            _repository.Save();
        }

        public void DeleteTodoItem(long id)
        {
            _repository.DeleteEntity((int) id);
            _repository.Save();
        }
    }
}