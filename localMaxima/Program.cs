using System;

namespace localMaxima
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 5);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\n");

            if (array[1] <= array[0])
            {
                Console.WriteLine(array[0]);
            }

            for (int i = 1; i < array.Length - 1; i++)
            {    
                if ((array[i] >= array[i - 1]) && (array[i] >= array[i + 1]))
                {
                    Console.WriteLine(array[i]);
                }
            }

            if (array[array.Length - 2] <= array[array.Length - 1])
            {
                Console.WriteLine(array[array.Length - 1]);
            }
        }
    }
}
