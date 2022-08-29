using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool isWork = true;

            while (isWork)
            {
                DrawMenu();

                ManageList(numbers, ref isWork);

                Console.Clear();
            }
        }

        static void DrawMenu()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Введите число");
            Console.WriteLine("Введите \"sum\", чтобы получить сумму всех чисел");
            Console.WriteLine("Введите \"exit\" для выхода из программы");
            Console.SetCursorPosition(0, 0);
        }

        static void ManageList(List<int> numbers, ref bool isWork)
        {
            string userInput;
            const string Sum = "sum";
            const string Exit = "exit";

            userInput = Console.ReadLine();

            switch (userInput.ToLower())
            {
                case Sum:
                    Console.WriteLine("Сумма всех чисел равна - " + numbers.Sum());
                    Console.ReadKey();
                    break;

                case Exit:
                    isWork = false;
                    break;

                default:
                    numbers.Add(Convert.ToInt32(userInput));
                    break;
            }
        }
    }
}
