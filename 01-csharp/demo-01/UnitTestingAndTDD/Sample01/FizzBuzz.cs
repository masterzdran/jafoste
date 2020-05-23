using System;
using System.Text;

namespace Sample01
{
    public class FizzBuzz
    {
        public const string MultipleOf3Result = "Fizz";
        public const string MultipleOf5Result = "Buzz";
        public const string MultipleOf3And5Result = "FizzBuzz";
        public const string IllegalArgumentExceptionMaxMinorThanMin = "The max parameter must be greater than min parameter.";
        public const string IllegalArgumentExceptionMinMustBePositive = "The min parameter must be positive";
        public FizzBuzz()
        {
                
        }

        
        public virtual string MultipleOf3(int number)
        {
            return (number != 0 && number % 3 == 0) ? MultipleOf3Result : number.ToString();
        }
        
        public virtual string MultipleOf5(int number) {
            return (number != 0 && number % 5 == 0) ? MultipleOf5Result : number.ToString();
        }

        public virtual string MultipleOf3And5(int number) {
            return (number != 0 && number % 3 == 0 && number % 5 == 0) ? MultipleOf3And5Result : number.ToString();
        }

        public string ProcessRange(in int min, in int max)
        {
            if (max < min) {
                throw new ArgumentException(IllegalArgumentExceptionMaxMinorThanMin);
            }
            if (min < 1) {
                throw new ArgumentException(IllegalArgumentExceptionMinMustBePositive);
            }
            
            StringBuilder result = new StringBuilder();

            for (int idx = min; idx <= max; idx++) {
                result.AppendLine(this.Process(idx));
            }
            return result.ToString();
        }

        private string Process(in int idx)
        {
            if (idx % 5 == 0 && idx % 3 == 0) {
                return MultipleOf3And5(idx);
            }
            if (idx % 5 == 0) {
                return MultipleOf5(idx);
            }
            if (idx % 3 == 0) {
                return MultipleOf3(idx);
            }
            return idx.ToString();
        }
    }
}