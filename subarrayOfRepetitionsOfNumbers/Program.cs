using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subarrayOfRepetitionsOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumber = new int[30];
            int[] arrayNumberRepetition = new int[0];
            int tempNumber;
            int countRepetition;
            Random random = new Random();
            
            for (int i = 0; i < arrayNumber.Length; i++)
            {
                arrayNumber[i] = random.Next(1, 5);
            }

            for (int i = 0; i < arrayNumber.Length; i++)
            {
                Console.Write(arrayNumber[i] + " ");
            }

            for (int i = 0; i < arrayNumber.Length; i++)
            {
                tempNumber = arrayNumber[i];
                for (int j = 0; tempNumber == arrayNumber[i]; j++)
                {
                    arrayNumberRepetition[j] = arrayNumber[i];
                    Console.Write(arrayNumberRepetition[j] + " ");
                }
            }
        }
    }
}
