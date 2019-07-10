using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {


            var calculator = new Calculator();
            int answer = calculator.Divide(42, 0);
            Console.WriteLine($"THe answer is {answer}");

        }
    }
}
