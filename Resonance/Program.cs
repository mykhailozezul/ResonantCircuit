using Resonance.Services;
using System.ComponentModel;

namespace Resonance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? val = Console.ReadLine();

            Unit unit1 = new Unit();

            unit1.Value = val;

            Console.WriteLine(unit1.Value);
            Console.WriteLine(unit1.SIValue.ToString("0.##################################"));

            Console.ReadLine();
        }
    }
}
