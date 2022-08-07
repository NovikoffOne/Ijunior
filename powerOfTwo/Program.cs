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
            int minNumber = 1;
            int maxNumber = 100;
            int number = random.Next(minNumber, maxNumber);
            // Искомое число
            int raisedNumber = 2;
            // Искомая степень
            int raisedDegree = 1;

            while (number > Math.Pow(raisedNumber, raisedDegree))
            {
                raisedDegree++;
            }

            Console.WriteLine($"{number} меньше {raisedNumber}^{raisedDegree} равное {Math.Pow(raisedNumber, raisedDegree)}");
            Console.ReadKey();
        }
    }
}
