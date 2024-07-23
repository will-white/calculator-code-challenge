namespace Tests;

using CalculatorConsole;

public class ConsoleTests
{
    [Theory]
    [InlineData("20", "20")]
    [InlineData("1,5000", "5001")]
    public void ShouldAcceptStringInput(string numbers, string expected)
    {
        var writer = new StringWriter();
        Console.SetOut(writer);
        var reader = new StringReader(numbers + "\r\n");
        Console.SetIn(reader);

        Program.Main([]);

        var output = writer.ToString().Split("\n")[1];

        Assert.Equal(expected, output);
    }
}