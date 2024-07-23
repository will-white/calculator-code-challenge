public interface ICalculatorOptions
{
    bool AllowNegative { get; set; }
    string AltDelimiter { get; set; }
    int UpperBound { get; set; }
    bool TestMode { get; set; }
}