using System.Text.RegularExpressions;

namespace StringCalculator;

public static partial class Calculator
{
    public static string Calculate(
        string str,
        string altDelimiter = "\n",
        bool allowNegativeNumbers = false,
        int upperBound = 1000)
    {
        string[] arr = ParseAndSplitString(str, altDelimiter);

        int value = 0;
        List<int> negativeValues = [];
        List<int> parsedValues = [];
        foreach (var item in arr)
        {
            var parsedValue = int.TryParse(item, out int v) ? v : 0;

            if (!allowNegativeNumbers && parsedValue < 0) negativeValues.Add(parsedValue);
            else if (parsedValue > upperBound) parsedValue = 0;

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