namespace TestSimulator;
using Simulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(15, 10, 20, 15)]
    [InlineData(25, 5, 15, 15)]
    [InlineData(-10, 0, 10, 0)]
    [InlineData(50, 30, 40, 40)]
    public void Validator_Limiter_ShouldPassCorrectly(int value, int min, int max, int output)
    {
        Assert.Equal(output, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("   Fiona    ", 4, 15, '*', "Fiona")]
    [InlineData("      ", 6, 12, '%', "%%%%%%")]
    [InlineData("  gingerbread man  ", 8, 20, '-', "Gingerbread")]
    [InlineData("Prince Charming, a vain and self-absorbed man.", 1, 14, '.', "Prince Charming")]
    [InlineData("d                          ragon", 2, 8, '!', "D!!")]
    public void Validator_Shortener_ShouldPassCorrectly(string value, int min, int max, char placeholder, string output)
    {
        Assert.Equal(output, Validator.Shortener(value, min, max, placeholder));
    }
}
