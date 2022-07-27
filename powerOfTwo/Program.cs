using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powerOfTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            int two = 2;
            int degreeTwo = 1;

            while (number > Math.Pow(two, degreeTwo))
            {
                degreeTwo++;
            }

            Console.WriteLine($"{number} меньше {two}^{degreeTwo} равное {Math.Pow(two, degreeTwo)}");
        }
    }
}
