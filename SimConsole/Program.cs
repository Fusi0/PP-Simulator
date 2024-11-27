using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Starting Simulator!\n");
            Console.WriteLine("Starting positions");
            SmallSquareMap map = new(5);
            //List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
            //List<Point> points = [new(2, 2), new(3, 1)];
            List<Creature> creatures = [new Orc("Shrek"), new Elf("Leonidas"), new Elf("Scoia'tel")];
            List<Point> points = [new(0, 0), new(4, 2),new(3,3)];
            string moves = "dlrludl";
            Simulation simulation = new(map, creatures, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);
            var move = 1;
            mapVisualizer.Draw();
            while (!simulation.Finished)
            {
                Console.WriteLine("Press any key to proceed to the next turn...");
                Console.ReadKey(true);

                Console.WriteLine($"Tura {move}");
                Console.Write($"{simulation.CurrentCreature.Info} {simulation.CurrentCreature.Position} goes {simulation.CurrentMoveName}\n");
                Console.WriteLine();
                simulation.Turn();
                mapVisualizer.Draw();
                move++;
            }
        }
    }
}