using System;

namespace Simulator;

public class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            name = value.Trim();
            if (name.Length > 25)
            {
                name = name[..25].Trim();
            }
            if (name.Length < 3)
            {
                name = name.PadRight(3, '#');
            }
            if (char.IsLower(name[0]))
            {
                name = char.ToUpper(name[0]) + name[1..];
            }
        }
    }

    private int level = 1;
    public int Level
    {
        get => level;
        set
        {
            if (level == 1)
            {
                level = value < 1 ? 1 : value > 10 ? 10 : value;
            }
        }
    }

    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public void Upgrade()
    {
        if (Level < 10)
        {
            level++;
        }
    }

    public string Info => $"{Name} [{Level}]";
}
