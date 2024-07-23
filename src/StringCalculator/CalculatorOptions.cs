public class CalculatorOptions : ICalculatorOptions
{
    public bool AllowNegative { get; set; }
    public string AltDelimiter { get; set; } = "\n";
    public int UpperBound { get; set; } = 1000;
    public bool TestMode { get; set; }
}