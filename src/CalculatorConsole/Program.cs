using StringCalculator;

namespace CalculatorConsole
{
    public class Program
    {
        public static void Main(string[]? args)
        {
            var options = ParseCommandLineArguments(args);

            Console.CancelKeyPress += (s, e) =>
            {
                Console.WriteLine("Exiting...");
                e.Cancel = false;
            };

            do
            {
                Console.WriteLine("Please enter a string to calculate: ");

                var input = Console.ReadLine();
                var calculator = new Calculator(options);
                Console.WriteLine(calculator.Calculate(input ?? ""));
            } while (!options.TestMode);
        }

        private static ICalculatorOptions ParseCommandLineArguments(string[]? args)
        {
            var options = new CalculatorOptions();
            if (args != null)
            {
                foreach (var arg in args)
                {
                    if (arg == "--allowNegative")
                    {
                        options.AllowNegative = true;
                    }
                    else if (arg.StartsWith("--altDelimiter"))
                    {
                        options.AltDelimiter = arg.Split("=")[1];
                    }
                    else if (arg.StartsWith("--upperBound") && int.TryParse(arg.Split("=")[1], out int num))
                    {
                        options.UpperBound = num;
                    }
                    else if (arg == "--testing")
                    {
                        options.TestMode = true;
                    }
                }
            }

            return options;
        }
    }
}