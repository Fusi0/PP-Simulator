using Simulator.Maps;
using Simulator;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(15)]
    [InlineData(18)]
    [InlineData(14)]
    [InlineData(6)]
    [InlineData(9)]
    public void SmallSquareMap_Create_ShouldNotThrowAnException(int size)
    {
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(-1)]
    [InlineData(25)]
    [InlineData(40)]
    public void SmallSquareMap_Create_ShouldThrowAnExeption(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Fact]
    public void SmallSquareMap_PointExists_ShouldReturnCorrect()
    {
        var map = new SmallSquareMap(12);
        var point1 = new Point(4, 4);
        var point2 = new Point(12, 4);
        var point3 = new Point(5, 18);
        var point4 = new Point(-2, -3);
        var point5 = new Point(11, 6);
        Assert.True(map.Exist(point1));
        Assert.False(map.Exist(point2));
        Assert.False(map.Exist(point3));
        Assert.False(map.Exist(point4));
        Assert.True(map.Exist(point5));
    }

    [Theory]
    [InlineData(7, 4, 4, Direction.Up, 4, 5)]
    [InlineData(7, 4, 4, Direction.Down, 4, 3)]
    [InlineData(7, 4, 4, Direction.Right, 5, 4)]
    [InlineData(7, 4, 4, Direction.Left, 3, 4)]
    [InlineData(12, 11, 5, Direction.Up, 11, 6)]
    [InlineData(12, 11, 5, Direction.Right, 11, 5)]
    [InlineData(12, 10, 5, Direction.Right, 11, 5)]
    [InlineData(8, 1, 1, Direction.Left, 1, 1)]
    [InlineData(8, 1, 1, Direction.Down, 1, 1)]
    [InlineData(8, 1, 1, Direction.Right, 2, 1)]
    public void SmallSquareMap_Next_ShouldReturnCorrect(int mapSize, int x, int y, Direction direction, int nextX, int nextY)
    {
        var map = new SmallSquareMap(mapSize);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        var expectedPoint = new Point(nextX, nextY);
        Assert.Equal(nextPoint, expectedPoint);
    }

    [Theory]
    [InlineData(7, 4, 4, Direction.Up, 5, 5)]
    [InlineData(12, 10, 5, Direction.Right, 11, 4)]
    [InlineData(7, 4, 4, Direction.Left, 3, 5)]
    [InlineData(12, 11, 5, Direction.Up, 11, 5)]
    [InlineData(12, 11, 5, Direction.Right, 11, 5)]
    [InlineData(8, 1, 1, Direction.Left, 1, 1)]
    [InlineData(8, 1, 1, Direction.Down, 1, 1)]
    [InlineData(8, 1, 1, Direction.Right, 1, 1)]
    [InlineData(8, 1, 1, Direction.Up, 2, 2)]
    public void SmallSquareMap_NextDiagonal_ShouldReturnCorrect(int mapSize, int x, int y, Direction direction, int nextX, int nextY)
    {
        var map = new SmallSquareMap(mapSize);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        var expectedPoint = new Point(nextX, nextY);
        Assert.Equal(nextPoint, expectedPoint);
    }
}
