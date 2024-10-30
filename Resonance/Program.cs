using Resonance.Models;
using Resonance.Services;
using Resonance.Services.Circuits;

namespace Resonance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit R1 = new Unit();
            Unit R2 = new Unit();
            Unit C = new Unit();

            R1.ParametricValue = "0";
            R2.ParametricValue = "4.3";
            C.ParametricValue = "3.4u";

            var timer = new Timer555(R1, R2, C);

            var list = new List<SweepContainer>() { 
                new SweepContainer(timer.R2, 
                new Unit() 
                {
                    ParametricValue="1" 
                }, 
                new Unit() 
                {
                    ParametricValue="8"
                }, 
                new Unit() 
                { 
                    ParametricValue="1"
                })
            };

            string output = UnitSweep.Sweep(timer, list, Timer555.ASTABLE_MODE, SweepModesEnum.FollowEndVal);

            Console.WriteLine(output);

            output = UnitSweep.Sweep(timer, list, Timer555.ASTABLE_MODE, SweepModesEnum.FollowStep);

            Console.WriteLine(output);

            output = UnitSweep.Sweep(timer, list, Timer555.ASTABLE_MODE, SweepModesEnum.FollowEndValAndStep);

            Console.WriteLine(output);
        }
        
    }
}
