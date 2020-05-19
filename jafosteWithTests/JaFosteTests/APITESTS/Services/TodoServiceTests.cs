using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Services;
using Models;
using Models.Abstractions;
using Moq;
using Shouldly;
using Xunit;

namespace JaFosteTests.APITESTS.Services
{
    public class TodoServiceTests
    {
        //It has one dependency: IRepository<TodoItem>
        // 
        private readonly Mock<IRepository<TodoItem>> _todoItemRepositoryMock = new Mock<IRepository<TodoItem>>();
        private readonly TodoService _todoService;
        
        public TodoServiceTests()
        {
              _todoService = new TodoService(_todoItemRepositoryMock.Object);  
        }
        
        
        [Fact]
        public async Task GetTodoItem_ShouldReturnTodoItem_WhenExists()
        {
            //Arrange
            var id = 1;
            var todoItemObj = getTodoItem(id);
            var filter = It.IsAny<Expression<Func<TodoItem,bool>>>();
            _todoItemRepositoryMock.Setup( 
                    repo => repo.Get(filter ,null,""  )
                    )
                .ReturnsAsync(todoItemObj);
            //Act
            TodoItem todoItem = await _todoService.GetTodoItem(id);

            //Assert
            todoItem.ShouldBeSameAs(todoItemObj.FirstOrDefault());
        }


        private  IEnumerable<TodoItem> getTodoItem(int id)
        {
            var item = new TodoItem
            {
                Id = id,
                Name = "Teste",
                IsComplete = false
            };

            var list = new LinkedList<TodoItem>();
            list.AddLast(item);
            return list;
        }
    }
}