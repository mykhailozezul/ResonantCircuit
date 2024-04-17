using Resonance.Services;

namespace Resonance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? val = Console.ReadLine();

            Unit unit1 = new Unit();

            unit1.ParametricValue = val;

            Console.WriteLine(unit1.ParametricValue);
            Console.WriteLine(unit1.SIValue.ToString("0.##################################"));
            Console.WriteLine("VALS");

            foreach (var item in Unit.ListParametricUnitForAllExps(unit1))
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
