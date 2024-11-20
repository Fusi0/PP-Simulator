using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(2, 3, 8, 7)]
    [InlineData(4, 6, 9, 12)]
    [InlineData(7, 8, 4, 6)]
    [InlineData(-10, 5, -7, 2)]
    public void Rectangle_Create_ShouldPassCorrectly(int x1, int y1, int x2, int y2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(Math.Min(x1, x2), rectangle.X1);
        Assert.Equal(Math.Min(y1, y2), rectangle.Y1);
        Assert.Equal(Math.Max(x1, x2), rectangle.X2);
        Assert.Equal(Math.Max(y1, y2), rectangle.Y2);
    }

    [Theory]
    [InlineData(3, 3, 3, 3)]
    [InlineData(4, 7, 4, 8)]
    [InlineData(2, 10, 3, 10)]
    [InlineData(-6, -3, -6, -9)]
    [InlineData(6, 4, -6, 4)]
    public void Rectangle_Create_ShouldThrowAnExeption(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Theory]
    [InlineData(2, 3, 8, 7, 5, 5)]
    [InlineData(-6, -10, 6, 10, 0, 0)]
    [InlineData(-6, -10, 6, 10, -3, -4)]
    public void Rectangle_ConsistsPoint_ShouldContainPoint(int x1, int y1, int x2, int y2, int pointX, int pointY)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(pointX, pointY);
        Assert.True(rectangle.Contains(point));
    }

    [Theory]
    [InlineData(-6, -10, 6, 10, -12, -15)]
    [InlineData(3, 3, 7, 7, 10, 5)]
    [InlineData(-6, -10, 6, 10, 7, 11)]
    [InlineData(-2, 4, -5, 8, -6, 12)]
    public void Rectangle_ConsistsPoint_ShouldNotContainPoint(int x1, int y1, int x2, int y2, int pointX, int pointY)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(pointX, pointY);
        Assert.False(rectangle.Contains(point));
    }
}
