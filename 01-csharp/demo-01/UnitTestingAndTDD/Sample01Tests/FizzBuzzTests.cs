using System;
using Sample01;
using Sample01Tests.Abstractions;
using Shouldly;
using Xunit;

namespace Sample01Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(15)]
        public virtual void MultipleOf3_Should_print_Fizz(int number)
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();

            // Act
            var result = fizzBuzz.MultipleOf3(number);
            
            // Assert
            result.ShouldNotBeNull();
            result.Trim().ShouldNotBeEmpty();
            IsDigit(result).ShouldBeFalse();
            result.ShouldBe(FizzBuzz.MultipleOf3Result);
        }
        
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(20)]
        [InlineData(25)]
        public virtual void multipleOf5_Should_print_Buzz(int number)
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();

            // Act
            var result = fizzBuzz.MultipleOf5(number);
            
            // Assert
            result.ShouldNotBeNull();
            result.Trim().ShouldNotBeEmpty();
            IsDigit(result).ShouldBeFalse();
            result.ShouldBe(FizzBuzz.MultipleOf5Result);
        }
        
        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        [InlineData(75)]        
        [InlineData(90)]
        public virtual void multipleOf3And5_Should_print_FizzBuzz(int number)
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();

            // Act
            var result = fizzBuzz.MultipleOf3And5(number);
            
            // Assert
            result.ShouldNotBeNull();
            result.Trim().ShouldNotBeEmpty();
            IsDigit(result).ShouldBeFalse();
            result.ShouldBe(FizzBuzz.MultipleOf3And5Result);
        }   
        
        [Theory]
        [InlineData(1,100)]
        public void processRange_Should_Print_Expected_String(int min, int max)
        {
            // Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();

            // Act
            String result = fizzBuzz.ProcessRange(min,max);

            // Assert
            result.ShouldNotBeNull();
            result.Trim().ShouldNotBeEmpty();
            result.ShouldBe(FizzBuzzTestsExpectations.ExpectedString);
        }
        
        [Theory]
        [InlineData(2,1)]
        [InlineData(0,0)]
        [InlineData(-1,1)]
        [InlineData(int.MinValue,int.MaxValue)]
        public void ProcessRange_Should_Throw_IllegalArgumentException_With_Invalid_Parameters(int min, int max)
        {
            // Arrange
            FizzBuzz fizzBuzz = new FizzBuzz();

            // Act | Assert expect exception
            Assert.Throws<ArgumentException>(() => fizzBuzz.ProcessRange(min,max));

        }
        
        protected static bool IsDigit(String value) {
            if (value == null) {
                return false;
            }
            try {
                double d = Double.Parse(value);
            } catch (Exception nfe) {
                return false;
            }
            return true;
        }
    }
}