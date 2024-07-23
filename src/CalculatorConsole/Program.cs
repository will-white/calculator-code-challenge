using StringCalculator;

namespace CalculatorConsole
{
    public class Program
    {
        public static void Main(string[]? args)
        {
            bool testing = false;
            if (args != null)
            {
                foreach (var arg in args)
                {
                    if (arg == "--testing")
                    {
                        testing = true;
                    }
                }
            }

            Console.CancelKeyPress += (s, e) =>
            {
                Console.WriteLine("Exiting...");
                e.Cancel = false;
            };

            do
            {
                Console.WriteLine("Please enter a string to calculate: ");

                var input = Console.ReadLine();

                Console.WriteLine(Calculator.Calculate(input ?? ""));
            } while (!testing);
        }
    }
}