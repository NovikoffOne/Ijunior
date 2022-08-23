using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int convertNumber = TryParse();
        }

        static int TryParse()
        {
            bool succes = false;
            int number = 0;

            while (succes != true)
            {
                int tempNumber;

                Console.Write("Введите элемент для конвертации : ");
                string value = Console.ReadLine();

                succes = int.TryParse(value, out tempNumber);

                if (succes == true)
                {
                    Console.WriteLine("Успех - " + tempNumber);
                    number = tempNumber;
                }
                else
                {
                    Console.WriteLine("Не удалось, попробуйте еще раз!");
                }
            }

            return number;
        }
    }
}
