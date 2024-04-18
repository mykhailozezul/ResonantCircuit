namespace Resonance.Services
{
    public class LCSeries
    {
        public Unit L { get; set; }
        public Unit C { get; set; }
        public Unit F { get; set; }
        public Unit R { get; set; }
        public Unit XL { get; set; }
        public Unit Q { get; set; }
        public Unit BW { get; set; }
        public Unit BW_FL { get; set; }
        public Unit BW_FH { get; set; }

        public LCSeries(Unit? r, Unit? l, Unit? c, Unit? f)
        {
            if (r != null) R = r;
            if (l != null) L = l;
            if (c != null) C = c;
            if (f != null) F = f;
        }

        public static void F_LC(LCSeries lc)
        {
            Calc_F(lc);
            Workflow(lc);
        }

        public static void L_FC(LCSeries lc)
        {          
            Calc_L(lc);
            Workflow(lc);
        }

        public static void C_FL(LCSeries lc)
        {
            Calc_C(lc);
            Workflow(lc);
        }

        static void Workflow(LCSeries lc)
        {
            Calc_XL(lc);
            Calc_Q(lc);
            Calc_BW(lc);
        }

        static void Calc_F(LCSeries lc)
        {
            if (lc.L == null || lc.C == null)
                return;
            if (lc.F == null)
                lc.F = new Unit();
            lc.F.SIValue = 1 / (2 * Math.PI * Math.Sqrt(lc.L.SIValue * lc.C.SIValue));
        }

        static void Calc_C(LCSeries lc)
        {
            if (lc.F == null || lc.L == null)
                return;
            if (lc.C == null)
                lc.C = new Unit();
            lc.C.SIValue = 1 / (Math.Pow(2 * Math.PI * lc.F.SIValue, 2) * lc.L.SIValue);
        }

        static void Calc_L(LCSeries lc)
        {
            if (lc.F == null || lc.C == null)
                return;
            if (lc.L == null)
                lc.L = new Unit();
            lc.L.SIValue = 1 / (Math.Pow(2 * Math.PI * lc.F.SIValue, 2) * lc.C.SIValue);
        }

        static void Calc_XL(LCSeries lc)
        {
            if (lc.F == null || lc.L == null)
                return;
            if (lc.XL == null)
                lc.XL = new Unit();
            lc.XL.SIValue = 2 * Math.PI * lc.F.SIValue * lc.L.SIValue;
        }

        static void Calc_Q(LCSeries lc)
        {
            if (lc.XL == null || lc.R == null)
                return;
            if (lc.Q == null)
                lc.Q = new Unit();
            lc.Q.SIValue = lc.XL.SIValue / lc.R.SIValue;
        }

        static void Calc_BW(LCSeries lc)
        {
            if (lc.Q == null || lc.F == null)
                return;
            if (lc.BW == null)
                lc.BW = new Unit();
            lc.BW.SIValue = lc.F.SIValue / lc.Q.SIValue;
            if (lc.BW_FL == null)
                lc.BW_FL = new Unit();
            lc.BW_FL.SIValue = lc.F.SIValue - 0.5 * lc.BW.SIValue;
            if (lc.BW_FH == null)
                lc.BW_FH = new Unit();
            lc.BW_FH.SIValue = lc.F.SIValue + 0.5 * lc.BW.SIValue;
        }


    }
}
