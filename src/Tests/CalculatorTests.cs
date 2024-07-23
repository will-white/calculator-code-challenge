namespace Tests;

using StringCalculator;

public class CalculatorTests
{
    [Theory]
    [InlineData("20", 20)]
    [InlineData("1,5000", 5001)]
    [InlineData("4, -3", 1)]
    public void ShouldAddAllNumbers(string numbers, int expected)
    {
        var result = Calculator.Calculate(numbers);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData("20, ", 20)]
    [InlineData("20,0", 20)]
    [InlineData("20, 0", 20)]
    [InlineData("5,tytyt", 5)]
    public void ShouldTreatEmptyOrInvalidAsZero(string numbers, int expected)
    {
        var result = Calculator.Calculate(numbers);

        Assert.Equal(result, expected);
    }

    [Fact]
    public void ShouldThrowOnMoreThanTwoValues()
    {
        Assert.Throws<Exception>(() => Calculator.Calculate("1,2,3"));
    }
}