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
            R.SIValue = 0.1;

            var lc = new LCSeries(R, L, C);

            var plc = new LCParallel(R, L, C);

            var simulation = new UnitSweep(
                new Unit() { ParametricValue="5000"},
                new Unit() { ParametricValue="20000"},
                new Unit() { ParametricValue="100"}
            );
            
            //UnitSweep.Sweep<LCSeries>(simulation,lc ,lc.L, LCSeries.F_LC);

            UnitSweep.Sweep<LCParallel>(simulation, plc, plc.F, LCParallel.Input_F);

            Console.WriteLine(simulation.OutputResult);


        }
        
    }
}
