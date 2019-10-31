using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Abstractions;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IRepository<TodoItem> _repository;

        public TodoItemsController(IRepository<TodoItem> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            var r = await _repository.Get(orderBy: c => c.OrderBy(n => n.Id));
            return r.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _repository.Get(filter: c => c.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem.FirstOrDefault();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _repository.UpdateEntity(todoItem);
            _repository.Save();
            return Ok();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {

            _repository.InsertEntity(todoItem);
            _repository.Save();
            return Ok();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {

            _repository.DeleteEntity((int)id);
            _repository.Save();
            return Ok();
        }
    }
}