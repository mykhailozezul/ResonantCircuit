using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resonance.Services
{
    public class Unit
    {
        private double _value { get; set; }
        private Prefixes _prefix { get; set; }
        public string Value { 
            get
            {
                return ConvertFromExp(_value, (int) _prefix)+ConvertPrefixToStr(_prefix);
            } 
            set
            {
                SplitValueFromPrefix(value, out double val, out Prefixes pref);
                _value = ConvertToExp(val, (int) pref);
                _prefix = pref;
            } 
        }
        public double SIValue { 
            get
            {
                return _value;
            }
        }
        public double ConvertFromExp(double val, int exponent)
        {
            return val / Math.Pow(10, exponent);
        }
        public double ConvertToExp(double val, int exponent)
        {
            return val * Math.Pow(10, exponent);
        }
        public void SplitValueFromPrefix(string inputString, out double val, out Prefixes pref)
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
            double.TryParse(inputString.Substring(0, lastLetterIndex), out val);
        }

        public string ConvertPrefixToStr(Prefixes pref)
        {
            string result = "";
            switch (pref)
            {
                case Prefixes.p:
                    result = "p";
                    break;
                case Prefixes.n:
                    result = "n";
                    break;
                case Prefixes.u:
                    result = "u";
                    break;
                case Prefixes.m:
                    result = "m";
                    break;
                case Prefixes.none:
                    result = "";
                    break;
                case Prefixes.k:
                    result = "k";
                    break;
                case Prefixes.meg:
                    result = "meg";
                    break;
                case Prefixes.g:
                    result = "g";
                    break;
                case Prefixes.t:
                    result = "t";
                    break;
            }
            return result;
        }

        public Prefixes ConvertStrToPrefix(string prefix)
        {
            Prefixes result = Prefixes.none;
            switch (prefix)
            {
                case "p": 
                    result = Prefixes.p; 
                    break;
                case "n": 
                    result = Prefixes.n; 
                    break;
                case "u":
                    result = Prefixes.u;
                    break;
                case "m":
                    result = Prefixes.m;
                    break;
                case "":
                    result = Prefixes.none;
                    break;
                case "k":
                    result = Prefixes.k;
                    break;
                case "meg":
                    result = Prefixes.meg;
                    break;
                case "g":
                    result = Prefixes.g;
                    break;
                case "t":
                    result = Prefixes.t;
                    break;
            }            
            return result;
        }

    }

    public enum Prefixes
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
