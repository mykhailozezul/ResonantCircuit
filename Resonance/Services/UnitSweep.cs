
using Resonance.Services.Interfaces;

namespace Resonance.Services
{
    public class UnitSweep(Unit startValue, Unit stopValue, Unit step)
    {
        public Unit StartValue { get; set; } = startValue;
        public Unit StopValue { get; set; } = stopValue;
        public Unit Step { get; set; } = step;        

        public delegate void Iterator<T>(T circuit);
        public string OutputResult { get; set; }

        public static void Sweep<T>(UnitSweep sweepSettings, T circuitModule, Unit valueToSweep, Iterator<T> calcFunction) where T : Circuit
        {            
            double range = sweepSettings.StopValue - sweepSettings.StartValue;
            int iterationsCount = (int)Math.Floor(range / sweepSettings.Step);
            double sweeper = sweepSettings.StartValue;
            string result = "";
            bool showColumnNames = true;
            for (int i = 0; i < iterationsCount; i++)
            {
                valueToSweep.SIValue = sweeper;
                calcFunction(circuitModule);                             
                result += circuitModule.Output(showColumnNames, circuitModule);                
                sweeper += sweepSettings.Step;
                showColumnNames = false;
            }
            sweepSettings.OutputResult = result;
        }
    }
}
