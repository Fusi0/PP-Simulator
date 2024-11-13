using System.ComponentModel.DataAnnotations;
using System;

using Simulator.Maps;
namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {

        //Console.WriteLine("Starting Simulator!\n");
        //Lab4a();
        //Creature c = new Elf("Elandor", 5, 3);
        //Console.WriteLine(c);
        //Lab4b();

        Lab5a();
    }
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
        };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }
    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }

    static void Lab5a()
    {
        Point p = new(10, 25);
        Rectangle r1 = new Rectangle(2, 2, 6, 7);
        Console.WriteLine($"Rectangle: {r1}");

        Rectangle r2 = new(4, 5, 2, 3);
        Console.WriteLine($"Rectangle: {r2}");

        try
        {
            Rectangle r3 = new Rectangle(0, 0, 2, 6);
            Console.WriteLine($"Wrong rectangle: {r3}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Point point1 = new Point(4, 4);
        Point point2 = new Point(7, 8);
        Point point3 = new Point(-2, -3);
        Point point4 = new Point(-10, -15);

        Rectangle r4 = new Rectangle(point1, point2);
        Console.WriteLine($"Rectangle: {r4}");

        Console.WriteLine("-----");

        Rectangle r5 = new Rectangle(-4, -6, 6, 8);
        Console.WriteLine($"Rectangle: {r5}");

        Console.WriteLine($"Contains (4,4) - {r5.Contains(point1)}");
        Console.WriteLine($"Contains (7,8) - {r5.Contains(point2)}");
        Console.WriteLine($"Contains (-2,-3) - {r5.Contains(point3)}");
        Console.WriteLine($"Contains (-10,-15) - {r5.Contains(point4)}");
    }

    static void Lab5b()
    {
        try
        {
            var map1 = new SmallSquareMap(10);
            Console.WriteLine($"Map {map1.Size}x{map1.Size} was created succesfully");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            var map2 = new SmallSquareMap(4);
            Console.WriteLine($"Map {map2.Size}x{map2.Size} was created succesfully");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            var map3 = new SmallSquareMap(20);
            Console.WriteLine($"Map {map3.Size}x{map3.Size} was created succesfully");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            var map4 = new SmallSquareMap(21);
            Console.WriteLine($"Map {map4.Size}x{map4.Size} was created succesfully");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("\n---Map 12x12---");
        var map = new SmallSquareMap(12);
        Point point1 = new Point(4, 5);
        Console.WriteLine($"Contains point (4,5) - {map.Exist(point1)}");

        Point point2 = new Point(11, 5);
        Console.WriteLine($"Contains point (11,5) - {map.Exist(point2)}");

        Point point3 = new Point(5, 14);
        Console.WriteLine($"Contains point (5,14) - {map.Exist(point3)}");

        Point point4 = new Point(-2, -3);
        Console.WriteLine($"Contains point (-2,-3) - {map.Exist(point4)}");

        Point point5 = new Point(8, 6);
        Console.WriteLine($"Contains point (8,6) - {map.Exist(point5)}");

        Console.WriteLine($"Next move up from (4,5) is: {map.Next(point1, Direction.Up)}");
        Console.WriteLine($"Next move up from (8,6) is: {map.Next(point5, Direction.Up)}");

        Console.WriteLine($"Next move right from (8,6) is: {map.Next(point5, Direction.Right)}");

        Console.WriteLine($"Next move diagonally up from (4,5) is: {map.NextDiagonal(point1, Direction.Up)}");
        Console.WriteLine($"Next move diagonally up from (8,6) is: {map.NextDiagonal(point5, Direction.Up)}");

        Console.WriteLine($"Next move diagonally down from (4,5) is: {map.NextDiagonal(point1, Direction.Down)}");
        Console.WriteLine($"Next move diagonally down from (8,6) is: {map.NextDiagonal(point5, Direction.Down)}");

    }
}
