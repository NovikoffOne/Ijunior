using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rand1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int number = rand.Next(0, 101);
            int auxiliaryVariable = 0;
            int sumVaribales = 0;

            Console.WriteLine("Рандомное число = " + number);

            for (int i = number; number >= auxiliaryVariable; auxiliaryVariable++ )
            {
                if ((auxiliaryVariable % 3) == 0)
                {
                    sumVaribales += auxiliaryVariable;
                }
                else if ((auxiliaryVariable % 5) == 0)
                {
                    sumVaribales += auxiliaryVariable;
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine($"Сумма всех чисел кратных 3 или 5, числа {number} = {sumVaribales}");
        }
    }
}
