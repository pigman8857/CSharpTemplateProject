namespace MyProject.Tests;

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Divide(double dividend, double divisor)
    {
        if (divisor == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return dividend / divisor;
    }
}

public class UnitTest1
{
    [Fact]
    public void TestName()
    {
        // Arrange
        var calc = new Calculator();

        // Act
        var result = calc.Add(2, 2);

        // Assert
        Assert.Equal(4, result);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    public void Add_MultipleValues_ReturnsExpectedSum(int a, int b, int expected)
    {
        var calc = new Calculator();
        var result = calc.Add(a, b);
        Assert.Equal(expected, result);
    }
}
