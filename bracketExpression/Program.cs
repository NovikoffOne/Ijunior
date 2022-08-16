using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bracketExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bracketExpression = "(((((((()";
            bool expressionCorrect = false;
            float bracketTemp = 0;

            for (int i = 0; i < bracketExpression.Length; i++)
            {
                if (bracketExpression[i] == "(")
                {
                    bracketTemp += 0.5f;
                }
                
                //Console.WriteLine(bracketExpression[i]);
                //if (bracketExpression == ")")
                //{
                //    expressionCorrect = false;
                //}
                //else
                //    expressionCorrect = true;
            }
            
            Console.WriteLine(expressionCorrect);
        }
    }
}
