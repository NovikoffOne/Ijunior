using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            int amountLine;

            Console.Write("Введите текст : ");
            message = Console.ReadLine();

            Console.Write("Введите количество : ");
            amount = Convert.ToInt32(Console.ReadLine());

            for (int count = 0; count < amountLine; count++)
            {
                Console.WriteLine(message);
            }
        }
    }
}
