package sample01;
public class FizzBuzz {
    public final String MultipleOf3 = "Fizz";
    public final String MultipleOf5 = "Buzz";
    public final String MultipleOf3And5 = "FizzBuzz";
    public final String IllegalArgumentExceptionMaxMinorThanMin = "The max parameter must be greater than min parameter.";
    public final String IllegalArgumentExceptionMinMustBePositive = "The min parameter must be positive";

    public String multipleOf3(int number) {
        return (number != 0 && number % 3 == 0) ? MultipleOf3 : Integer.toString(number);
    }

    public String multipleOf5(int number) {
        return (number != 0 && number % 5 == 0) ? MultipleOf5 : Integer.toString(number);
    }

    public String multipleOf3And5(int number) {
        return (number != 0 && number % 3 == 0 && number % 5 == 0) ? MultipleOf3And5 : Integer.toString(number);
    }

    public String processRange(int min, int max) {
        if (max < min) {
            throw new IllegalArgumentException(IllegalArgumentExceptionMaxMinorThanMin);
        }
        if (min < 1) {
            throw new IllegalArgumentException(IllegalArgumentExceptionMinMustBePositive);
        }

        StringBuffer result = new StringBuffer();

        for (int idx = min; idx <= max; idx++) {
            result.append(this.process(idx));
            result.append(System.lineSeparator());
        }
        return result.toString();
    }

    private String process(int idx) {
        if (idx % 5 == 0 && idx % 3 == 0) {
            return multipleOf3And5(idx);
        }
        if (idx % 5 == 0) {
            return multipleOf5(idx);
        }
        if (idx % 3 == 0) {
            return multipleOf3(idx);
        }
        return Integer.toString(idx);
    }
}
