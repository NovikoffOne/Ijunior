using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cycleFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int stopNumber = 100;
            int stepNumber = 7;

            for (int startNumber = 5; startNumber < stopNumber; startNumber += stepNumber)
            {
                Console.WriteLine(startNumber);
            }
        }
    }
}
