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
            int raisedNumber = 2;
            int degree = 1;

            while (number > Math.Pow(raisedNumber, degree))
            {
                degree++;
            }

            Console.WriteLine($"{number} меньше {raisedNumber}^{degree} равное {Math.Pow(raisedNumber, degree)}");
        }
    }
}
