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
            int divider1 = 3;
            int divider2 = 5;
            int startNumber = 0;
            int stopNumber = 101;
            Random random = new Random();
            int number = random.Next(startNumber, stopNumber);
            int auxiliaryVariable = 0;
            int sumVaribales = 0;

            Console.WriteLine("Рандомное число = " + number);

            for (int i = number; number >= auxiliaryVariable; auxiliaryVariable++ )
            {
                if ((auxiliaryVariable % divider1) == 0)
                {
                    sumVaribales += auxiliaryVariable;
                }
                else if ((auxiliaryVariable % divider2) == 0)
                {
                    sumVaribales += auxiliaryVariable;
                }
            }

            Console.WriteLine($"Сумма всех чисел кратных {divider1} или {divider2}, числа {number} = {sumVaribales}");
        }
    }
}
