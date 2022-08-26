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
            
            Shuffle(array);

            DrawShuffledArray(array);
        }

        static void Shuffle(int[] array)
        {
            int tempNumber;
            int randomIndex;
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                randomIndex = random.Next(0, array.Length);
                tempNumber = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = tempNumber;
            }
        }

        static void DrawShuffledArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
