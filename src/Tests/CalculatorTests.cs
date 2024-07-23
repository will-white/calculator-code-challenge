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

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("20, ", 20)]
    [InlineData("20,0", 20)]
    [InlineData("20, 0", 20)]
    [InlineData("5,tytyt", 5)]
    public void ShouldTreatEmptyOrInvalidAsZero(string numbers, int expected)
    {
        var result = Calculator.Calculate(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
    [InlineData("2,4,8,16,32", 62)]
    [InlineData("1,0,0,0,0", 1)]
    [InlineData("1,x,x,y,y", 1)]
    public void AllowMutipleNumbers(string numbers, int expected)
    {
        var result = Calculator.Calculate(numbers);

        Assert.Equal(expected, result);
    }
}