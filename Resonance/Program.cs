using Resonance.Services;
using Resonance.Services.Circuits;

namespace Resonance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Unit L = new Unit();
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

            Console.WriteLine(simulation.OutputResult);*/

            Unit R1 = new Unit();
            Unit R2 = new Unit();
            Unit C = new Unit();

            R1.ParametricValue = "0";
            R2.ParametricValue = "3";
            C.ParametricValue = "100u";

            var timer = new Timer555(R1, R2, C);

            var sim = new UnitSweep(
                new Unit() { ParametricValue="1u" },
                new Unit() { ParametricValue="10u" },
                new Unit() { ParametricValue="1u" }
            );

            UnitSweep.Sweep(sim, timer, timer.C, Timer555.ASTABLE_MODE);

            Console.WriteLine(sim.OutputResult);
        }
        
    }
}
