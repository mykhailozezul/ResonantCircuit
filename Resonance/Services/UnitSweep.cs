
namespace Resonance.Services
{
    public class UnitSweep
    {
        public Unit StartValue { get; set; }
        public Unit StopValue { get; set; }
        public Unit Step { get; set; }
        public UnitSweep(Unit startValue, Unit stopValue, Unit step)
        {
            StartValue = startValue;
            StopValue = stopValue;
            Step = step;
        }
        public delegate void Iterator<T>(T circuit);
        public delegate void Outputter<T>(T circuit, double stepValue);
        public void Sweep<T>(Unit valueToSweep, Iterator<T> recalcFunction, T circuitInst, Outputter<T>? outputFunction)
        {
            double range = StopValue.SIValue - StartValue.SIValue;
            int iterationsCount = (int)Math.Floor(range / Step.SIValue);
            double sweeper = StartValue.SIValue;
            for (int i = 0; i < iterationsCount; i++)
            {
                recalcFunction(circuitInst);
                valueToSweep.SIValue = sweeper;
                sweeper += Step.SIValue;
                if (outputFunction != null)
                {
                    outputFunction(circuitInst, sweeper);
                }
            }
        }        
    }
}
