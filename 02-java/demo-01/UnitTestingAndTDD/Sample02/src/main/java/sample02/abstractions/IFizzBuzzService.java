package sample02.abstractions;

public interface IFizzBuzzService {
    public final String MultipleOf3 = "Fizz";
    public final String MultipleOf5 = "Buzz";
    public final String MultipleOf3And5 = "FizzBuzz";
    public final String IllegalArgumentExceptionMaxMinorThanMin = "The max parameter must be greater than min parameter.";
    public final String IllegalArgumentExceptionMinMustBePositive = "The min parameter must be positive";

    String multipleOf3(int number);

    String multipleOf5(int number);

    String multipleOf3And5(int number);
}
