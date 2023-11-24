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

    public static class BoolExtra 
    {
        
        public static bool? BoolExpressionProcessing(string exp, Dictionary<char, bool> elems)
        {
            exp = new Parser(exp).postfixExpr;
            if (exp == null || exp.Contains('(') || exp.Contains(')')) return null;
            Stack<bool> stack = new();
            char c = ' ';
            for (int i = 0; i < exp.Length; i++) 
            {
                c = exp[i];
                if (c == ' ') continue;


                if (!BoolExtra.Parser.IsOperations(c) && elems.ContainsKey(c)) stack.Push(elems[c]);
                else 
                {
                    if (!BoolExtra.Parser.IsOperations(c) && !elems.ContainsKey(c)) return null;
                    if (c == '-') 
                    {
                        bool tmp = stack.Pop();
                        stack.Push(BoolLogic.Not(tmp));
                        continue;
                    }



                    if (stack.Count < 2) return null;
                    bool second = stack.Pop();
                    bool first = stack.Pop();
                     
                    stack.Push(Execute(c, first, second));
                }
            }
        return stack.Pop();
        }

        private static bool Execute(char op, bool first, bool second) => op switch
        {
            '&' => BoolLogic.And(first, second),
            '|' => BoolLogic.Or(first, second),
            '↔' => BoolLogic.XNOR(first, second),
            '←' => BoolLogic.NL(first, second),
            '→' => BoolLogic.NM(first, second),
            '^' => BoolLogic.XOR(first, second)
        };







        public class Parser
        {
            public string infixExpr { get; private set; }
            public string? postfixExpr { get; private set; }
            private Dictionary<char, int> operationPriority = new() {
                {'(', 0},
                {'↔', 1},
                {'^', 1},
                {'→', 2},
                {'←', 2},
                {'|', 2},
                {'&', 3},
                {'-', 4}	
            };

            
            public Parser(string expression)
            {
                infixExpr = expression;
                postfixExpr = ToPostfix(infixExpr);
            }


            public static bool IsOperations(char c) => c == '(' || c == '↔' || c == '→' || c == '|' || c == '&' || c == '-' || c == ')';






            private string? ToPostfix(string infixExpr)
            {
                string postfixExpr = "";
                Stack<char> stack = new();    
                for (int i = 0; i < infixExpr.Length; i++)
                {
                    char c = infixExpr[i];
                    if (!IsOperations(c))
                    {
                        postfixExpr += c;
                    }
                    else if (c == '(')
                    {
                        stack.Push(c);
                    }
                    else if (c == ')')
                    {
                        if (!stack.Contains('(')) return null;
                        while (stack.Count > 0 && stack.Peek() != '(')
                            postfixExpr += stack.Pop();
                        stack.Pop();
                    }
                    else if (operationPriority.ContainsKey(c))
                    {
                        char op = c;
                        while (stack.Count > 0 && (operationPriority[stack.Peek()] >= operationPriority[op]))
                            postfixExpr += stack.Pop();
                        stack.Push(op);
                    }
                }
                foreach (char op in stack)
                    postfixExpr += op;
                return postfixExpr;
            }
        }
    }

}
