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
            int termString = 1;
            // Складываемая строка
            int summedString = 1;
            
            // Количество перемножаемых столбцов
            int multipliedСolumns = 1;
            
            // Произведение столбцов
            int сolumnsMultiplication = 1;

            // Вычисляем сумму второй строки
            for (int i = 0; i < numberArray.GetLength(termString); i++)
            {
                sumLine += numberArray[summedString, i];
            }
            
            // Произведение чисел первого столбца
            for (int i = 0; i < numberArray.GetLength(0); i++)
            {
                for (int j = 0; j < multipliedСolumns; j++)
                {
                    сolumnsMultiplication *= numberArray[i, j];
                }
            }

            // Выводим исходную матрицу
            for (int i = 0; i < numberArray.GetLength(0); i++)
            {
                for (int j = 0; j < numberArray.GetLength(1); j++)
                {
                    Console.Write(numberArray[i, j] + " ");
                }

                Console.WriteLine();
            }
            
            // Выводим сумму строки
            Console.WriteLine(sumLine + " Сумма второй строки");
            
            // Выводим произведение столбцов
            Console.WriteLine(сolumnsMultiplication + " Произведение первого столбца");
        }
    }
}
