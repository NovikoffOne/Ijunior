using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayShift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumber = new int[] { 1, 2, 3, 4, 5, 6 };
            int userInput;
            
            userInput = Convert.ToInt32(Console.ReadLine());
            
            for (int count = 0; userInput > count; count++ )
            {
                int firstNumberArray;
                firstNumberArray = arrayNumber[0];
                
                for (int i = 0; i < arrayNumber.Length - 1; i++)
                {
                    arrayNumber[i] = arrayNumber[i + 1];
                }
                
                arrayNumber[arrayNumber.Length - 1] = firstNumberArray;
            }

            for (int i = 0; i < arrayNumber.Length; i++)
            {
                Console.Write(arrayNumber[i] + " ");
            }
        }
    }
}
