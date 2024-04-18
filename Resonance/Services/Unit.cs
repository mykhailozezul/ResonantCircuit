namespace Resonance.Services
{
    public class Unit
    {
        private double _value { get; set; }
        private Prefixes _prefix { get; set; }
        public string ParametricValue { 
            get
            {
                return ScaleDownToExp(_value, (int) _prefix) + _prefix.ToString();
            } 
            set
            {
                SplitValueFromPrefix(value, out double val, out Prefixes pref);
                _value = ScaleUpToExp(val, (int) pref);
                _prefix = pref;
            } 
        }        
        public double SIValue { 
            get
            {
                return _value;
            }
            set
            {
                _prefix = Prefixes.none;
                _value = value;
            }
        }
        public static List<string> ListParametricUnitForAllExps(Unit unit)
        {
            var result = new List<string>();
            foreach (Prefixes pref in Enum.GetValues(typeof(Prefixes)))
            {
                result.Add(ScaleDownToExp(unit.SIValue, (int) pref).ToString("0.##################") + pref.ToString());
            }
            return result;
        }
        static double ScaleDownToExp(double val, int exponent)
        {
            return val / Math.Pow(10, exponent);
        }
        static double ScaleUpToExp(double val, int exponent)
        {
            return val * Math.Pow(10, exponent);
        }
        static void SplitValueFromPrefix(string inputString, out double val, out Prefixes pref)
        {
            string prefResult = "";
            int lastLetterIndex = inputString.Length;
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                char c = inputString[i];
                if (char.IsLetter(c))
                {
                    prefResult = c + prefResult;
                    lastLetterIndex = i;
                }
                else
                {
                    i = 0;                    
                }                    
            }
            pref = ConvertStrToPrefix(prefResult);
            bool isSuccess = double.TryParse(inputString.Substring(0, lastLetterIndex), out double parsedValue);
            if (isSuccess)
            {
                val = parsedValue;
            }
            else
            {
                val = 0;
            }
        }

        static Prefixes ConvertStrToPrefix(string prefix)
        {            
            bool isSuccess = Enum.TryParse<Prefixes>(prefix, out Prefixes result);
            if (isSuccess)            
                return result;            
            else            
                return Prefixes.none;            
        }

    }

    enum Prefixes
    {
        p = -12,
        n = -9,
        u = -6,
        m = -3,
        none = 0,
        k = 3,
        meg = 6,
        g = 9,
        t = 12
    }
}
