using StringCalculator;

namespace CalculatorConsole
{
    public class Program
    {
        public static void Main(string[]? args)
        {
            Console.WriteLine("Please enter a string to calculate: ");

            var input = Console.ReadLine();

            Console.WriteLine(Calculator.Calculate(input ?? ""));
        }
    }
}