using Resonance.Services;

namespace Resonance.Models
{
    public class SweepContainer
    {
        public Unit CircuitValueReference { get; set; }
        public Unit StartVal { get; set; }
        public Unit StopVal { get; set; }
        public Unit Step { get; set; }
        public SweepContainer(Unit circuitValueReference, Unit start, Unit stop, Unit step)
        {
            CircuitValueReference = circuitValueReference;
            StartVal = start;
            StopVal = stop;
            Step = step;
        }
    }
}
