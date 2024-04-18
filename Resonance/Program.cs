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

            L.ParametricValue = "2m";
            C.ParametricValue = "10u";
            R.ParametricValue = "3";

            var lc = new LCSeries(R,L,C,null);

            LCSeries.F_LC(lc);

            Console.WriteLine("Q");
            Console.WriteLine(lc.Q.SIValue);
            Console.WriteLine("R");
            Console.WriteLine(lc.R.SIValue);
            Console.WriteLine("C");
            Console.WriteLine(lc.C.SIValue);
            Console.WriteLine("BW");
            Console.WriteLine(lc.BW.SIValue);
            Console.WriteLine("BW_FL");
            Console.WriteLine(lc.BW_FL.SIValue);
            Console.WriteLine("BW_FH");
            Console.WriteLine(lc.BW_FH.SIValue);
            Console.WriteLine("F");
            Console.WriteLine(lc.F.SIValue);
            Console.WriteLine("XL");
            Console.WriteLine(lc.XL.SIValue);
        }
    }
}
