using StringCalculator;

namespace CalculatorConsole
{
    public class Program
    {
        public static void Main(string[]? args)
        {
            var (allowNegativeNumbers, altDelimiter, upperBound, testing) = ParseCommandLineArguments(args);

            Console.CancelKeyPress += (s, e) =>
            {
                Console.WriteLine("Exiting...");
                e.Cancel = false;
            };

            do
            {
                Console.WriteLine("Please enter a string to calculate: ");

                var input = Console.ReadLine();

                Console.WriteLine(Calculator.Calculate(input ?? "", altDelimiter, allowNegativeNumbers, upperBound));
            } while (!testing);
        }

        private static (
            bool allowNegativeNumbers,
            string altDelimiter,
            int upperBound,
            bool testing)
            ParseCommandLineArguments(string[]? args)
        {
            bool allowNegativeNumbers = false;
            string altDelimiter = "\n";
            int upperBound = 1000;
            bool testing = false;

            if (args != null)
            {
                foreach (var arg in args)
                {
                    if (arg == "--allowNegative")
                    {
                        allowNegativeNumbers = true;
                    }
                    else if (arg.StartsWith("--altDelimiter"))
                    {
                        altDelimiter = arg.Split("=")[1];
                    }
                    else if (arg.StartsWith("--upperBound") && int.TryParse(arg.Split("=")[1], out int num))
                    {
                        upperBound = num;
                    }
                    else if (arg == "--testing")
                    {
                        testing = true;
                    }
                }
            }

            return (allowNegativeNumbers, altDelimiter, upperBound, testing);
        }
    }
}