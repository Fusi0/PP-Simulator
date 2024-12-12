using System;
namespace Simulator.Maps;
public interface IMappable
{
    public char Symbol { get; }
    void Go(Direction direction);
    public Point Position { get; }
    void InitMapAndPosition(Map map, Point position);
}
