
namespace StringCalculator;

public static class Calculator
{
    public static int Calculate(string str)
    {
        string[] arr = str.Split(',');

        if (arr.Length > 2) throw new Exception("More than 2 numbers");

        int value = 0;
        foreach (var item in arr)
        {
            value += int.TryParse(item, out int v) ? v : 0;
        }

        return value;
    }
}