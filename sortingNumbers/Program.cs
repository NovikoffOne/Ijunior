using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberArray = new int[10];
            int minBorder = 1;
            int maxBorder = 10;
            Random random = new Random();

            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = random.Next(minBorder, maxBorder);
            }

            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.Write(numberArray[i] + " ");
            }

            Console.WriteLine();

            for (int i = numberArray.Length - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++) 
                {
                    if (numberArray[j - 1] > numberArray[j])
                    {
                        int temp = numberArray[j - 1];
                        numberArray[j - 1] = numberArray[j];
                        numberArray[j] = temp;
                    }
                }

            }

            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.Write(numberArray[i] + " ");
            }
        }
    }
}
