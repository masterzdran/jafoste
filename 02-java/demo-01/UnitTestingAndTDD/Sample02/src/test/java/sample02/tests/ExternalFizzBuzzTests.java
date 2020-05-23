package sample02.tests;

import org.junit.Assert;
import org.junit.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;
import sample01.tests.FizzBuzzTests;
import sample02.ExternalFizzBuzz;
import sample02.abstractions.IFizzBuzzService;

import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class ExternalFizzBuzzTests extends FizzBuzzTests {

    @Override
    @Test
    public void multipleOf3_Should_print_Fizz()
    {
        // Arrange
        int number = 3;
        IFizzBuzzService service = mock(IFizzBuzzService.class);
        when(service.multipleOf3(number)).thenReturn(service.MultipleOf3);

        ExternalFizzBuzz fizzBuzz = new ExternalFizzBuzz(service);


        // Act
        String result = fizzBuzz.multipleOf3(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(service.MultipleOf3.equals(result));
    }

    @Override
    @ParameterizedTest
    @ValueSource(ints = {3,6,9,12,15,18,21})
    public void multipleOf3_Should_print_Fizz(int number)
    {
        // Arrange
        IFizzBuzzService service = mock(IFizzBuzzService.class);
        when(service.multipleOf3(number)).thenReturn(service.MultipleOf3);

        ExternalFizzBuzz fizzBuzz = new ExternalFizzBuzz(service);

        // Act
        String result = fizzBuzz.multipleOf3(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(service.MultipleOf3.equals(result));

    }

    @Override
    @Test
    public void multipleOf5_Should_print_Buzz()
    {
        // Arrange
        int number = 5;
        IFizzBuzzService service = mock(IFizzBuzzService.class);
        when(service.multipleOf5(number)).thenReturn(service.MultipleOf5);

        ExternalFizzBuzz fizzBuzz = new ExternalFizzBuzz(service);


        // Act
        String result = fizzBuzz.multipleOf5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(service.MultipleOf5.equals(result));
    }

    @Override
    @ParameterizedTest
    @ValueSource(ints = {5,10,15,20,25,30})
    public void multipleOf5_Should_print_Buzz(int number)
    {
        // Arrange
        IFizzBuzzService service = mock(IFizzBuzzService.class);
        when(service.multipleOf5(number)).thenReturn(service.MultipleOf5);

        ExternalFizzBuzz fizzBuzz = new ExternalFizzBuzz(service);


        // Act
        String result = fizzBuzz.multipleOf5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(service.MultipleOf5.equals(result));
    }

    @Override
    @Test
    public void multipleOf3And5_Should_print_FizzBuzz()
    {
        // Arrange
        int number = 15;
        IFizzBuzzService service = mock(IFizzBuzzService.class);
        when(service.multipleOf3And5(number)).thenReturn(service.MultipleOf3And5);

        ExternalFizzBuzz fizzBuzz = new ExternalFizzBuzz(service);


        // Act
        String result = fizzBuzz.multipleOf3And5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(service.MultipleOf3And5.equals(result));
    }

    @Override
    @ParameterizedTest
    @ValueSource(ints = {15, 30, 45, 60, 75, 90})
    public void multipleOf3And5_Should_print_FizzBuzz(int number)
    {
        // Arrange
        IFizzBuzzService service = mock(IFizzBuzzService.class);
        when(service.multipleOf3And5(number)).thenReturn(service.MultipleOf3And5);

        ExternalFizzBuzz fizzBuzz = new ExternalFizzBuzz(service);


        // Act
        String result = fizzBuzz.multipleOf3And5(number);

        // Assert
        Assert.assertNotNull(result);
        Assert.assertTrue(result.trim().length() > 0);
        Assert.assertFalse(isDigit(result));
        Assert.assertTrue(service.MultipleOf3And5.equals(result));
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
