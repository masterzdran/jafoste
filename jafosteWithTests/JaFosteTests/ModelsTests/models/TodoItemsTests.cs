using Models;
using Shouldly;
using Xunit;

namespace JaFosteTests.ModelsTests.models
{
    public sealed class TodoItemsTests
    {
        [Fact]
        public void TwoEqualTodoItemInstances_ShouldBe_Equal()
        {
            var todo1 = new TodoItem {Id = 1, Name = "TodoItem", IsComplete = false};
            var todo2 = new TodoItem {Id = 1, Name = "TodoItem", IsComplete = false};

            todo1.ShouldBe(todo2);
        }
        [Fact]
        public void TwoEqualTodoItemInstances_ShouldBe_Equal_WithSameHashCode()
        {
            var todo1 = new TodoItem {Id = 1, Name = "TodoItem", IsComplete = false};
            var todo2 = new TodoItem {Id = 1, Name = "TodoItem", IsComplete = false};

            todo1.GetHashCode().ShouldBe(todo2.GetHashCode());
        }     

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void SetIdWithValue_Should_Return_SameValue(int value)
        {
            var todo1 = new TodoItem {Id = value, Name = "TodoItem", IsComplete = false};
            
            todo1.Id.ShouldBe(value);
        }
        
        [Theory]
        [InlineData("Nome")]
        [InlineData("Outro Nome")]
        public void SetNameWithValue_Should_Return_SameValue(string value)
        {
            var todo1 = new TodoItem {Id = 1, Name = value, IsComplete = false};
            
            todo1.Name.ShouldBe(value);
        }
        
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetIsCompleteWithValue_Should_Return_SameValue(bool value)
        {
            var todo1 = new TodoItem {Id = 1, Name = "TodoItem", IsComplete = value};
            
            todo1.IsComplete.ShouldBe(value);
        }
    }
}