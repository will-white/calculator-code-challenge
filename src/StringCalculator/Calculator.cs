
namespace StringCalculator;

public static class Calculator
{
    public static int Calculate(string str)
    {
        string[] arr = ParseAndSplitString(str);

        int value = 0;
        List<int> negativeValues = [];
        foreach (var item in arr)
        {
            var parsedValue = int.TryParse(item, out int v) ? v : 0;

            if (parsedValue < 0) negativeValues.Add(parsedValue);
            else if (parsedValue > 1000) parsedValue = 0;

            value += parsedValue;
        }

        if (negativeValues.Count > 0)
            throw new Exception($"Negative values are NOT allowed. ({string.Join(", ", negativeValues)})");

        return value;
    }

    private static string[] ParseAndSplitString(string str)
    {
        var delimiters = new List<char> { ',', '\n' };

        if (str.StartsWith("//"))
        {
            string[] strings = str.Split('\n', 2);
            string delimiter = strings[0][2..];

            if (delimiter.Length > 1) throw new Exception("Only a single character is allowed");

            delimiters.Add(delimiter[0]);

            return strings[1].Split(delimiters.ToArray(), StringSplitOptions.None);
        }

        return str.Split(delimiters.ToArray(), StringSplitOptions.None);
    }
}