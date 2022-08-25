using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            Shuffle(ref array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static int[] Shuffle(ref int[] array)
        {
            int tempNumber;
            int j;
            Random random = new Random();
            j = random.Next(0, array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                tempNumber = array[i];
                array[i] = array[j];
                array[j] = tempNumber;
            }

            return array;
        }
    }
}
