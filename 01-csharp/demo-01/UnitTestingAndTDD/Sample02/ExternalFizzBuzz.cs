using Sample01;
using Sample02.Abstractions;

namespace Sample02
{
    public class ExternalFizzBuzz : FizzBuzz
    {
        private readonly IFizzBuzzService service;
        public ExternalFizzBuzz(IFizzBuzzService service) :base()
        {
            this.service=service;    
        }

        public override string MultipleOf3(int number)
        {
            return service.MultipleOf3(number);
        }

        public override string MultipleOf5(int number)
        {
            return service.MultipleOf5(number);
        }

        public override string MultipleOf3And5(int number)
        {
            return service.MultipleOf3And5(number);
        }
    }
}