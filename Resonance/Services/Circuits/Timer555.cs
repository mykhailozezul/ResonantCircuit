using Resonance.Services.Interfaces;

namespace Resonance.Services.Circuits
{
    public class Timer555: Circuit
    {
        Unit _F;
        Unit _R1;
        Unit _R2;
        Unit _C;
        Unit _TH; //Time High
        Unit _TL; //Time Low
        Unit _TX; //Time Period
        Unit _DC; //Duty Cycle

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

        public Unit R1
        {
            get
            {
                if (_R1 == null)
                    _R1 = new Unit();
                return _R1;
            }
            set
            {
                _R1 = value;
            }
        }

        public Unit R2
        {
            get
            {
                if (_R2 == null)
                    _R2 = new Unit();
                return _R2;
            }
            set
            {
                _R2 = value;
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

        public Unit TH
        {
            get
            {
                if (_TH == null)
                    _TH = new Unit();
                return _TH;
            }
            set
            {
                _TH = value;
            }
        }

        public Unit TL
        {
            get
            {
                if (_TL == null)
                    _TL = new Unit();
                return _TL;
            }
            set
            {
                _TL = value;
            }
        }

        public Unit TX
        {
            get
            {
                if (_TX == null)
                    _TX = new Unit();
                return _TX;
            }
            set
            {
                _TX = value;
            }
        }

        public Unit DC
        {
            get
            {
                if (_DC == null)
                    _DC = new Unit();
                return _DC;
            }
            set
            {
                _DC = value;
            }
        }

        public Timer555(Unit r1, Unit r2, Unit c)
        {
            R1 = r1;
            R2 = r2;
            C = c;
        }

        public static void ASTABLE_MODE(Timer555 t)
        {
            F_RRC(t);
            TH_RRC(t);
            TL_RRC(t);
            TX_RRC(t);
            DC_THTX(t);
        }

        static void F_RRC(Timer555 t)
        {
            t.F.SIValue = 1.44 / ((t.R1 + (2 * t.R2)) * t.C);
        }

        static void TH_RRC(Timer555 t)
        {
            t.TH.SIValue = 0.693 * (t.R1 + t.R2) * t.C;
        }

        static void TL_RRC(Timer555 t)
        {
            t.TL.SIValue = 0.693 * t.R2 * t.C;
        }

        static void TX_RRC(Timer555 t)
        {
            t.TX.SIValue = 0.693 * (t.R1 + (2 * t.R2)) * t.C;
        }

        static void DC_THTX(Timer555 t)
        {
            t.DC.SIValue = (t.TH / t.TX) * 100;
        }
    }
}
