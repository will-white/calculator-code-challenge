namespace Tests;

using CalculatorConsole;

public class ConsoleTests
{
    [Theory]
    [InlineData("20", "20 = 20")]
    [InlineData("66,33", "66+33 = 99")]
    public void ShouldAcceptStringInput(string numbers, string expected)
    {
        var writer = new StringWriter();
        Console.SetOut(writer);
        var reader = new StringReader(numbers + "\r\n");
        Console.SetIn(reader);

        Program.Main(["--testing"]);

        var output = writer.ToString().Split("\n")[1];

        Assert.Equal(expected, output);
    }
}