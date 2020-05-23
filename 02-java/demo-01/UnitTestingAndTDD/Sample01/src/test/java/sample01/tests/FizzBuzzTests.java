package sample01.tests;
import sample01.tests.abstractions.FizzBuzzTestsExpectations;
import org.junit.Assert;
import org.junit.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;
import org.junit.jupiter.params.provider.ValueSource;
import sample01.FizzBuzz;

public class FizzBuzzTests {
    @Test
    public void multipleOf3_Should_print_Fizz()
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();
        int number = 3;

        // Act
        String result = fizzBuzz.multipleOf3(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(fizzBuzz.MultipleOf3.equals(result));

    }

    @ParameterizedTest
    @ValueSource(ints = {3,6,9,12,15,18,21})
    public void multipleOf3_Should_print_Fizz(int number)
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();

        // Act
        String result = fizzBuzz.multipleOf3(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(fizzBuzz.MultipleOf3.equals(result));

    }

    @ParameterizedTest
    @ValueSource(ints = {Integer.MIN_VALUE,-1,0,1,2,4,5,Integer.MAX_VALUE})
    public void nonMultipleOf3_Should_print_Number(int number)
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();

        // Act
        String result = fizzBuzz.multipleOf3(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertTrue(isDigit(result));
        Assert.assertTrue(Integer.parseInt(result)==number);

    }

    @Test
    public void multipleOf5_Should_print_Buzz()
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();
        int number = 5;

        // Act
        String result = fizzBuzz.multipleOf5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(fizzBuzz.MultipleOf5.equals(result));
    }

    @ParameterizedTest
    @ValueSource(ints = {5,10,15,20,25,30})
    public void multipleOf5_Should_print_Buzz(int number)
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();

        // Act
        String result = fizzBuzz.multipleOf5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(fizzBuzz.MultipleOf5.equals(result));
    }
    @ParameterizedTest
    @ValueSource(ints = {Integer.MIN_VALUE, Integer.MAX_VALUE, 21,43,67,99})
    public void nonMultipleOf5_Should_print_Number(int number)
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();

        // Act
        String result = fizzBuzz.multipleOf5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertTrue(isDigit(result));
        Assert.assertTrue(Integer.parseInt(result)==number);
    }

    @Test
    public void multipleOf3And5_Should_print_FizzBuzz()
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();
        int number = 15;

        // Act
        String result = fizzBuzz.multipleOf3And5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(fizzBuzz.MultipleOf3And5.equals(result));
    }

    @ParameterizedTest
    @ValueSource(ints = {15, 30, 45, 60, 75, 90})
    public void multipleOf3And5_Should_print_FizzBuzz(int number)
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();

        // Act
        String result = fizzBuzz.multipleOf3And5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(fizzBuzz.MultipleOf3And5.equals(result));
    }
    @ParameterizedTest
    @ValueSource(ints = {Integer.MIN_VALUE, Integer.MAX_VALUE, 0, 1 ,16,41,88,33})
    public void nonMultipleOf3And5_Should_print_Number(int number)
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();

        // Act
        String result = fizzBuzz.multipleOf3And5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertTrue(isDigit(result));
        Assert.assertTrue(Integer.parseInt(result) == number);
    }

    @Test
    public void processRange_Should_Print_Expected_String()
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();
        int min = 1, max=100;

        // Act
        String result = fizzBuzz.processRange(min,max);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertTrue(result.equals(FizzBuzzTestsExpectations.ExpectedString));
    }

    @ParameterizedTest
    @CsvSource({"1,100"})
    public void processRange_Should_Print_Expected_String(int min, int max)
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();

        // Act
        String result = fizzBuzz.processRange(min,max);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertTrue(result.equals(FizzBuzzTestsExpectations.ExpectedString));
    }

    @ParameterizedTest
    @CsvSource({"2,1","0,0","-1,1"})
    public void processRange_Should_Throw_IllegalArgumentException_With_Invalid_Parameters(int min, int max)
    {
        // Arrange
        FizzBuzz fizzBuzz = new FizzBuzz();

        // Act | Assert expect exception
        Assert.assertThrows(
                IllegalArgumentException.class,
                () -> fizzBuzz.processRange(min,max)
        );

    }


    private static boolean isDigit(String value) {
        // src: https://www.baeldung.com/java-check-string-number
        if (value == null) {
            return false;
        }
        try {
            double d = Double.parseDouble(value);
        } catch (NumberFormatException nfe) {
            return false;
        }
        return true;
    }
}
