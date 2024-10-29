
using Resonance.Models;
using Resonance.Services.Interfaces;

namespace Resonance.Services
{
    public class UnitSweep
    {      
        public delegate void Iterator<T>(T circuit);


        public static string Sweep<T>(T circuitModule, List<SweepContainer> sweepList, Iterator<T> calcFunction, SweepModesEnum mode) where T : Circuit
        {            
            string result = "";

            int count = GetLargestIterationCount(sweepList);

            for (int i = 0; i <= count; i++)
            {
                foreach (var container in sweepList)
                {
                    if (mode == SweepModesEnum.FollowEndVal)
                    {
                        double step = (container.StopVal - container.StartVal) / count;
                        container.CircuitValueReference.SIValue = container.StartVal + (step * i);
                    }
                    if (mode == SweepModesEnum.FollowStep)
                    {
                        double step = (Math.Abs(container.StopVal - container.StartVal) / (container.StopVal - container.StartVal)) * container.Step;
                        container.CircuitValueReference.SIValue = container.StartVal + (step * i);
                    }
                    if (mode == SweepModesEnum.FollowEndValAndStep)
                    {
                        int steps = GetIterationsNum(container);
                        double step = (Math.Abs(container.StopVal - container.StartVal) / (container.StopVal - container.StartVal)) * container.Step;
                        if (i > steps)
                        {
                            container.CircuitValueReference.SIValue = container.StartVal + (step * steps);
                        }
                        else
                        {
                            container.CircuitValueReference.SIValue = container.StartVal + (step * i);
                        }                        
                    }
                }

                calcFunction(circuitModule);

                if (i == 0)
                {
                    result += circuitModule.Output(true, circuitModule);
                }
                result += circuitModule.Output(false, circuitModule);
            }

            return result;
        }        

        static int GetLargestIterationCount(List<SweepContainer> list)
        {
            int result = 0;
            foreach (var container in list)
            {
                int iterations = GetIterationsNum(container);
                if (iterations > result)
                {
                    result = iterations;
                }
            }
            return result;
        }

        static int GetIterationsNum(SweepContainer container)
        {
            double range = Math.Abs(container.StopVal - container.StartVal);
            return (int)Math.Floor(range / container.Step);
        }
    }
}
