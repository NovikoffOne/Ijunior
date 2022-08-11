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

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    if (array[i + 1] <= array[i])
                    {
                        Console.WriteLine(array[i]);
                    }
                }

                else if (i == array.Length - 1)
                {
                    if (array[i - 1] <= array[i])
                    {
                        Console.WriteLine(array[i]);
                    }
                }
                    
                else if ((array[i] >= array[i - 1]) && (array[i] >= array[i + 1]))
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}
