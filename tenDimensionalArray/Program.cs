using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tenDimensionalArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = int.MinValue;
            int[,] tenDimensionalArray = {
                {2, 3, 5, 7, 8, 9, 5, 3, 7, 34},
                {4, 65, 44, 76, 75, 234, 54, 645, 7, 1 },
                {6, 46, 87, 68, 345, 39, 425, 123, 57, 34},
                {22, 3, 57, 76, 83, 91, 52, 36, 73, 434},
                {234, 365, 577, 745, 38, 79, 85, 93, 57, 34},
                {25, 34, 51, 127, 84, 93, 56, 34, 71, 8},
                {24, 233, 435, 57, 68, 19, 45, 33, 27, 34},
                {44, 53, 56, 78, 89, 90, 568, 398, 877, 78},
                {287, 365, 56, 77, 98, 765, 56, 53, 37, 74},
                {27, 34, 55, 75, 88, 97, 55, 63, 74, 374},
            };

            Console.WriteLine("Исходная матрица");

            for (int i = 0; i < tenDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < tenDimensionalArray.GetLength(1); j++)
                {
                    Console.Write(tenDimensionalArray[i, j] + " ");
                    
                    if (maxNumber < tenDimensionalArray[i, j])
                    {
                        maxNumber = tenDimensionalArray[i, j];
                    }
                }
                
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < tenDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < tenDimensionalArray.GetLength(1); j++)
                {
                    if (maxNumber == tenDimensionalArray[i, j])
                    {
                        tenDimensionalArray[i, j] = 0;
                    }
                }
            }

            Console.WriteLine(maxNumber + " максимальное число");
            Console.WriteLine();
            Console.WriteLine("Измененная матрица");

            for (int i = 0; i < tenDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < tenDimensionalArray.GetLength(1); j++)
                {
                    Console.Write(tenDimensionalArray[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
