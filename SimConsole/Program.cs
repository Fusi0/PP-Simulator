using Simulator;
using Simulator.Maps;

namespace SimConsole;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor"), new Animals("Rabbits", 8), new Birds("Eagle", 14, true), new Birds("Ostrich", 2, false) };

        //SmallTorusMap map = new(8, 6);
        //List<Point> points = new() { new(2, 2), new(3, 1), new(1, 1), new(2, 5), new(3, 3) };
        //string moves = "xuldrxrdlxuxdruldxurd";
        
        BigBounceMap map = new(8, 6);
        List<Point> points = new() { new(2, 2), new(3, 1), new(1, 1), new(2, 5), new(3, 3) };
        string moves = "rduldrudurdludrdd";

        Simulation simulation = new(map, mappables, points, moves);
        SimulationHistory history = new(simulation);
        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();

            Console.WriteLine("\nPress any key to make a move...");
            Console.ReadKey(true);
            //Console.Write($"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}\n");
            simulation.Turn();
            history.SaveState();
            Console.Clear();
        }
        mapVisualizer.Draw();
        Console.WriteLine("\nSimulation finished!");

        foreach (int turn in new[] { 5, 10, 15, 20 })
        {
            try
            {
                var state = history.GetStateAtTurn(turn);
                Console.WriteLine($"Turn {turn}:");
                mapVisualizer.Draw(state);
                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Turn {turn} is out of range.");
            }
        }
    }
}