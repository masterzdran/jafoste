package sample02;
import sample01.FizzBuzz;
import sample02.abstractions.IFizzBuzzService;

public class ExternalFizzBuzz extends FizzBuzz {
    private final IFizzBuzzService service;
    public ExternalFizzBuzz(IFizzBuzzService service) {
        super();
        this.service=service;
    }

    @Override
    public String multipleOf3(int number) {
        return service.multipleOf3(number);
    }

    @Override
    public String multipleOf5(int number) {
        return service.multipleOf5(number);
    }

    @Override
    public String multipleOf3And5(int number) {
        return service.multipleOf3And5(number);
    }
}
