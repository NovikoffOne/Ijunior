using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workingWithStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] numberArray = { { 6, 3, 5, 7, 9 }, { 2, 4, 6, 8, 0 } };
            int sumLine = 0;
            int summedString = 1;
            int сolumnsMultiplication = 1;
            int multipliedColumn = 0;

            for (int i = 0; i < numberArray.GetLength(1); i++)
            {
                sumLine += numberArray[summedString, i];
            }

            for (int i = 0; i < numberArray.GetLength(0); i++)
            {
                сolumnsMultiplication *= numberArray[i, multipliedColumn];
            }

            for (int i = 0; i < numberArray.GetLength(0); i++)
            {
                for (int j = 0; j < numberArray.GetLength(1); j++)
                {
                    Console.Write(numberArray[i, j] + " ");
                }

                Console.WriteLine();
            }
            
            Console.WriteLine(sumLine + " Сумма второй строки");
            Console.WriteLine(сolumnsMultiplication + " Произведение первого столбца");
        }
    }
}
