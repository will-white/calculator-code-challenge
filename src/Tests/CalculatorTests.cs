namespace Tests;

using StringCalculator;

public class CalculatorTests
{
    [Theory]
    [InlineData("20", 20)]
    [InlineData("1,999", 1000)]
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

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("2,4\n8\n16,32", 62)]
    public void AllowNewLineDelimiter(string numbers, int expected)
    {
        var result = Calculator.Calculate(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("4, -3", "-3")]
    [InlineData("-1,5,-8", "-1, -8")]
    public void NegativeValuesShouldThrowAndDisplayNegativeValues(string numbers, string expectedValues)
    {
        var exception = Assert.Throws<Exception>(() => Calculator.Calculate(numbers));

        Assert.Contains(expectedValues, exception.Message);
    }

    [Theory]
    [InlineData("2,1001,6", 8)]
    [InlineData("33,1000,78", 1111)]
    [InlineData("2,999,6", 1007)]
    public void ShouldZeroOutNumbersAboveUpperBound(string numbers, int expected)
    {
        var result = Calculator.Calculate(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//#\n2#5", 7)]
    [InlineData("//,\n2,ff,100", 102)]
    public void AllowForCustomSingleCharDelimiter(string numbers, int expected)
    {
        var result = Calculator.Calculate(numbers);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldThrowWhenMoreThanTwoCharactersForSingleDelimiter()
    {
        Assert.Throws<Exception>(() => Calculator.Calculate("//||\n2||5"));
    }

    [Theory]
    [InlineData("//[***]\n11***22***33", 66)]
    [InlineData("//[||]\n11||22||33", 66)]
    [InlineData("//[||]\n11||22,33", 66)]
    public void AllowForCustomAnyLengthCharDelimiter(string numbers, int expected)
    {
        var result = Calculator.Calculate(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//[*][!!][r9r]\n11r9r22*hh*33!!44", 110)]
    [InlineData("//[*][!!][r9r]\n11r9r22,hh\n33!!44", 110)]
    public void AllowForMultipleCustomDelimiters(string numbers, int expected)
    {
        var result = Calculator.Calculate(numbers);

        Assert.Equal(expected, result);
    }
}