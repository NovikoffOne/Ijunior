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
                array[i] = random.Next(0, 100);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == array[0])
                {
                    if (array[i + 1] < array[i])
                    {
                        Console.WriteLine(array[i]);
                    }
                    else
                    {
                        continue;
                    }
                }
                
                else if ((array[i] == array[array.Length - 1]) && (array[i - 1] < array[i]))
                {
                    Console.WriteLine(array[i]);
                }

                else if ((array[i] > array[i - 1]) && (array[i] > array[i + 1]))
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}
