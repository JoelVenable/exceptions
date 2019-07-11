using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var calculator = new Calculator();
                Console.WriteLine($"Does this work??");

                int answer = calculator.Divide(42, 0);
                Console.WriteLine($"THe answer is {answer}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Whoops!!");
            }

        }
    }
}
