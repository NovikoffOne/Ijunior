using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchForCriminal
{
    static class UserUtils
    {
        public static int ReadInt()
        {
            int number;

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Данные неверны...");
            }

            return number;
        }
    }
}
