using Resonance.Services;
using Resonance.Services.Circuits;

namespace Resonance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit L = new Unit();
            Unit C = new Unit();
            Unit R = new Unit();

            L.ParametricValue = "2u";
            C.ParametricValue = "100u";
            R.SIValue = 0.01;

            var lc = new LCSeries(R, L, C);

            var simulation = new UnitSweep(
                new Unit() { ParametricValue="2u"},
                new Unit() { ParametricValue="200u"},
                new Unit() { ParametricValue="5u"}
            );
            
            UnitSweep.Sweep<LCSeries>(simulation,lc ,lc.L, LCSeries.F_LC);

            Console.WriteLine(simulation.OutputResult);


        }
        
    }
}
