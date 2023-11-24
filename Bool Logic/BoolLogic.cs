using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bool_Logic
{
    public static class BoolLogic
    {
        public static bool Not(bool value) => !value;

        public static bool And(bool first, bool second) => first && second;
        public static bool Or(bool first, bool second) => first || second;

        public static bool XNOR(bool first, bool second) => first == second;

        public static bool XOR(bool first, bool second) => first != second;

        public static bool NM(bool first, bool second) => first == second || (!first && (!second || second));

        public static bool NL(bool first, bool second) => NM(second, first);

    }
    public delegate bool boolMethod(bool first, bool second);


    public static class BoolDemonstration 
    {
        public static string GetSting(boolMethod method) 
        {
            string str = "a b     |" + 'a' + ' ' + method.Method.Name + ' '+'b' + '\n';
            str += false + " " + false + " " + method(false, false) + '\n';
            str += false + " " + true + " " + method(false, true) + '\n';
            str += true + " " + false + " " + method(true, false) + '\n';
            str += true + " " + true + " " + method(true, true) + '\n';


            return str;
        }
    }

    




}
