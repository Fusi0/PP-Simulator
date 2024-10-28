using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    public string Name { get; set; }
    public int Level { get; set; }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public string Info => $"{Name} <{Level}>";

    public void SayHi()
    {
        Console.WriteLine($"Hi, I am {Name}!");
    }
}

