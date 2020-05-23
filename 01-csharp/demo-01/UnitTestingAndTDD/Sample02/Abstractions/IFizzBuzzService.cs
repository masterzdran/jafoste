namespace Sample02.Abstractions
{
    public interface IFizzBuzzService
    {
        public const string MultipleOf3Result = "Fizz";
        public const string MultipleOf5Result = "Buzz";
        public const string MultipleOf3And5Result = "FizzBuzz";
        public const string IllegalArgumentExceptionMaxMinorThanMin = "The max parameter must be greater than min parameter.";
        public const string IllegalArgumentExceptionMinMustBePositive = "The min parameter must be positive";

        public string MultipleOf3(int number);

        public string MultipleOf5(int number);

        public string MultipleOf3And5(int number);  
    }
}