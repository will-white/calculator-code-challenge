
namespace StringCalculator;

public static class Calculator
{
    public static int Calculate(string str)
    {
        string[] arr = str.Split([',', '\n']);

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
}