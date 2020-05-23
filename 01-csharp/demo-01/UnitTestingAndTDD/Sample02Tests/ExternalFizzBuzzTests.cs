using Moq;
using Sample02.Abstractions;
using Shouldly;
using Xunit;
using Sample02;

namespace Sample02Tests
{
    using Sample01Tests;
    public class ExternalFizzBuzzTests : FizzBuzzTests
    {
        
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(15)]
        public override void MultipleOf3_Should_print_Fizz(int number)
        {
            // Arrange
            var service = new Mock<IFizzBuzzService>();
            service.Setup(m => m.MultipleOf3(It.IsAny<int>()))
                .Returns(IFizzBuzzService.MultipleOf3Result);
            var fizzBuzz = new ExternalFizzBuzz(service.Object);
            
            // Act
            var result = fizzBuzz.MultipleOf3(number);
            
            // Assert
            result.ShouldNotBeNull();
            result.Trim().ShouldNotBeEmpty();
            IsDigit(result).ShouldBeFalse();
            result.ShouldBe(IFizzBuzzService.MultipleOf3Result);
        }
        
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(20)]
        [InlineData(25)]
        public override void multipleOf5_Should_print_Buzz(int number)
        {
            // Arrange
            var service = new Mock<IFizzBuzzService>();
            service.Setup(m => m.MultipleOf5(It.IsAny<int>()))
                .Returns(IFizzBuzzService.MultipleOf5Result);
            var fizzBuzz = new ExternalFizzBuzz(service.Object);
            
            // Act
            var result = fizzBuzz.MultipleOf5(number);
            
            // Assert
            result.ShouldNotBeNull();
            result.Trim().ShouldNotBeEmpty();
            IsDigit(result).ShouldBeFalse();
            result.ShouldBe(IFizzBuzzService.MultipleOf5Result);
        }
        
        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        [InlineData(75)]        
        [InlineData(90)]
        public override void multipleOf3And5_Should_print_FizzBuzz(int number)
        {
            // Arrange
            var service = new Mock<IFizzBuzzService>();
            service.Setup(m => m.MultipleOf3And5(It.IsAny<int>()))
                .Returns(IFizzBuzzService.MultipleOf3And5Result);
            var fizzBuzz = new ExternalFizzBuzz(service.Object);
            
            // Act
            var result = fizzBuzz.MultipleOf3And5(number);
            
            // Assert
            result.ShouldNotBeNull();
            result.Trim().ShouldNotBeEmpty();
            IsDigit(result).ShouldBeFalse();
            result.ShouldBe(IFizzBuzzService.MultipleOf3And5Result);
        }
    }
}