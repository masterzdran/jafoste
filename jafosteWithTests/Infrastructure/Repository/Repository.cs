using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Repository
{
    public sealed class Repository : GenericRepository<TodoItem>
    {
        public Repository(TodoContext dbContext) : base(dbContext)
        {
        }
    }
}
