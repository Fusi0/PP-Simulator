using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData(20, 35)]
    [InlineData(25, 13)]
    [InlineData(-5, 2)]
    [InlineData(3, -10)]
    [InlineData(4, 6)]
    [InlineData(12, -8)]
    [InlineData(-10, 15)]
    public void Point_Create_ShouldPassCorrectly(int x, int y)
    {
        var point = new Point(x, y);
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    [InlineData(7, 7, Direction.Up, 7, 8)]
    [InlineData(7, 7, Direction.Down, 7, 6)]
    [InlineData(7, 7, Direction.Right, 8, 7)]
    [InlineData(7, 7, Direction.Left, 6, 7)]
    [InlineData(15, 10, Direction.Up, 15, 11)]
    [InlineData(15, 10, Direction.Right, 16, 10)]
    [InlineData(14, 10, Direction.Right, 15, 10)]
    [InlineData(2, 2, Direction.Left, 1, 2)]
    [InlineData(2, 2, Direction.Down, 2, 1)]
    [InlineData(2, 2, Direction.Right, 3, 2)]
    [InlineData(-10, 20, Direction.Up, -10, 21)]
    [InlineData(-10, 20, Direction.Down, -10, 19)]
    [InlineData(-10, 20, Direction.Left, -11, 20)]
    [InlineData(-10, 20, Direction.Right, -9, 20)]
    public void Point_Next_ShouldPassCorecctly(int x, int y, Direction d, int nextX, int nextY)
    {
        var point = new Point(x, y);
        var nextPoint = new Point(nextX, nextY);
        Assert.Equal(nextPoint, point.Next(d));
    }

    [Theory]
    [InlineData(3, 3, Direction.Down, 2, 2)]
    [InlineData(5, 5, Direction.Up, 6, 6)]
    [InlineData(12, 6, Direction.Right, 13, 5)]
    [InlineData(6, 6, Direction.Left, 5, 7)]
    [InlineData(15, 8, Direction.Up, 16, 9)]
    [InlineData(15, 8, Direction.Right, 16, 7)]
    [InlineData(4, 4, Direction.Left, 3, 5)]
    [InlineData(4, 4, Direction.Down, 3, 3)]
    [InlineData(4, 4, Direction.Right, 5, 3)]
    [InlineData(4, 4, Direction.Up, 5, 5)]
    [InlineData(-10, 25, Direction.Up, -9, 26)]
    [InlineData(-10, 25, Direction.Down, -11, 24)]
    [InlineData(-10, 25, Direction.Left, -11, 26)]
    [InlineData(-10, 25, Direction.Right, -9, 24)]
    public void Point_NextDiagonal_ShouldPassCorecctly(int x, int y, Direction d, int nextX, int nextY)
    {
        var point = new Point(x, y);
        var nextPoint = new Point(nextX, nextY);
        Assert.Equal(nextPoint, point.NextDiagonal(d));
    }
}
