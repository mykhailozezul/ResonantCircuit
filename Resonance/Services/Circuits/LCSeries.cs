using Resonance.Services.Interfaces;

namespace Resonance.Services.Circuits
{
    public class LCSeries : Circuit
    {
        Unit _L;
        Unit _C;
        Unit _F;
        Unit _R;
        Unit _XL;
        Unit _XC;
        Unit _Q;
        Unit _BW;
        Unit _BW_FL;
        Unit _BW_FH;
        Unit _Z;
        public Unit L
        {
            get
            {
                if (_L == null)
                    _L = new Unit();
                return _L;
            }
            set
            {
                _L = value;
            }
        }
        public Unit C
        {
            get
            {
                if (_C == null)
                    _C = new Unit();
                return _C;
            }
            set
            {
                _C = value;
            }
        }
        public Unit F
        {
            get
            {
                if (_F == null)
                    _F = new Unit();
                return _F;
            }
            set
            {
                _F = value;
            }
        }
        public Unit R
        {
            get
            {
                if (_R == null)
                    _R = new Unit();
                return _R;
            }
            set
            {
                _R = value;
            }
        }
        public Unit XL
        {
            get
            {
                if (_XL == null)
                    _XL = new Unit();
                return _XL;
            }
            set
            {
                _XL = value;
            }
        }
        public Unit XC
        {
            get
            {
                if (_XC == null)
                    _XC = new Unit();
                return _XC;
            }
            set
            {
                _XC = value;
            }
        }
        public Unit Q
        {
            get
            {
                if (_Q == null)
                    _Q = new Unit();
                return _Q;
            }
            set
            {
                _Q = value;
            }
        }
        public Unit BW
        {
            get
            {
                if (_BW == null)
                    _BW = new Unit();
                return _BW;
            }
            set
            {
                _BW = value;
            }
        }
        public Unit BW_FL
        {
            get
            {
                if (_BW_FL == null)
                    _BW_FL = new Unit();
                return _BW_FL;
            }
            set
            {
                _BW_FL = value;
            }
        }
        public Unit BW_FH
        {
            get
            {
                if (_BW_FH == null)
                    _BW_FH = new Unit();
                return _BW_FH;
            }
            set
            {
                _BW_FH = value;
            }
        }
        public Unit Z
        {
            get
            {
                if (_Z == null)
                    _Z = new Unit();
                return _Z;
            }
            set
            {
                _Z = value;
            }
        }

        public LCSeries(Unit? r, Unit? l, Unit? c)
        {
            R = r;
            L = l;
            C = c;                      
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

        public static void Input_F(LCSeries lc)
        {
            Workflow(lc);
        }

        static void Workflow(LCSeries lc)
        {
            Calc_XL(lc);
            Calc_XC(lc);
            Calc_Q(lc);
            Calc_BW(lc);
            Calc_Z(lc);
        }

        static void Calc_F(LCSeries lc)
        {
            lc.F.SIValue = 1 / (2 * Math.PI * Math.Sqrt(lc.L * lc.C));
        }

        static void Calc_C(LCSeries lc)
        {
            lc.C.SIValue = 1 / (Math.Pow(2 * Math.PI * lc.F, 2) * lc.L);
        }

        static void Calc_L(LCSeries lc)
        {
            lc.L.SIValue = 1 / (Math.Pow(2 * Math.PI * lc.F, 2) * lc.C);
        }

        static void Calc_XL(LCSeries lc)
        {
            lc.XL.SIValue = 2 * Math.PI * lc.F * lc.L;
        }

        static void Calc_XC(LCSeries lc)
        {
            lc.XC.SIValue = 1 / (2 * Math.PI * lc.F * lc.C);
        }

        static void Calc_Q(LCSeries lc)
        {
            lc.Q.SIValue = lc.XL / lc.R;
        }

        static void Calc_BW(LCSeries lc)
        {
            lc.BW.SIValue = lc.F / lc.Q;
            lc.BW_FL.SIValue = lc.F - 0.5 * lc.BW;
            lc.BW_FH.SIValue = lc.F + 0.5 * lc.BW;
        }

        static void Calc_Z(LCSeries lc)
        {
            Calc_XL(lc);
            Calc_XC(lc);
            lc.Z.SIValue = lc.R + (lc.XL - lc.XC);
        }                        

    }
}
