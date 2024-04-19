using Resonance.Services;

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

            var lc = new LCSeries(R, L, C, null);

            var simulation = new UnitSweep(
                new Unit() { ParametricValue="2u"},
                new Unit() { ParametricValue="200u"},
                new Unit() { ParametricValue="5u"}
            );
            
            simulation.Sweep<LCSeries>(lc.L, LCSeries.F_LC, lc, Output);
                               
        }
        public static void OutputAxises()
        {
            Console.Write("X ");
            Console.Write("Q ");
            Console.Write("R ");
            Console.Write("C ");
            Console.Write("BW ");
            Console.Write("BW_FL ");
            Console.Write("BW_FH ");
            Console.Write("F ");
            Console.Write("XL ");
            Console.WriteLine();
        }
        public static void Output(LCSeries lc, double xAxis)
        {
            Console.Write(xAxis);
            Console.Write(" ");
            Console.Write(lc.Q.SIValue);
            Console.Write(" ");
            Console.Write(lc.R.SIValue);
            Console.Write(" ");
            Console.Write(lc.C.SIValue);
            Console.Write(" ");
            Console.Write(lc.BW.SIValue);
            Console.Write(" ");
            Console.Write(lc.BW_FL.SIValue);
            Console.Write(" ");
            Console.Write(lc.BW_FH.SIValue);
            Console.Write(" ");
            Console.Write(lc.F.SIValue);
            Console.Write(" ");
            Console.Write(lc.XL.SIValue);
            Console.WriteLine();
        }
    }
}
