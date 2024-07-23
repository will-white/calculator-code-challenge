using System.Text.RegularExpressions;

namespace StringCalculator;

public partial class Calculator(ICalculatorOptions options)
{
    private readonly ICalculatorOptions _options = options ?? new CalculatorOptions();

    public string Calculate(string str)
    {
        string[] arr = ParseAndSplitString(str, _options.AltDelimiter);

        int value = 0;
        List<int> negativeValues = [];
        List<int> parsedValues = [];
        foreach (var item in arr)
        {
            var parsedValue = int.TryParse(item, out int v) ? v : 0;

            if (!_options.AllowNegative && parsedValue < 0) negativeValues.Add(parsedValue);
            else if (parsedValue > _options.UpperBound) parsedValue = 0;

            parsedValues.Add(parsedValue);
            value += parsedValue;
        }

        if (negativeValues.Count > 0)
            throw new Exception($"Negative values are NOT allowed. ({string.Join(", ", negativeValues)})");

        return $"{string.Join("+", parsedValues)} = {value}";
    }

    private static string[] ParseAndSplitString(string str, string altDelimiter)
    {
        var delimiters = new List<string> { ",", altDelimiter };

        if (str.StartsWith("//"))
        {
            string[] strings = str.Split('\n', 2);
            string delimiter = strings[0][2..];

            if (delimiter.StartsWith('['))
            {
                delimiters.AddRange(
                    DelimiterRegex()
                        .Matches(delimiter)
                        .Select(m => m.Groups[0].Value));
            }
            else if (delimiter.Length > 1)
            {
                throw new Exception("Single delimiter only allows for a single character");
            }
            else
            {
                delimiters.Add(delimiter);
            }

            return strings[1].Split(delimiters.ToArray(), StringSplitOptions.None);
        }

        return str.Split(delimiters.ToArray(), StringSplitOptions.None);
    }

    [GeneratedRegex(@"[^\[^\]]+", RegexOptions.Singleline)]
    private static partial Regex DelimiterRegex();
}