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
                const string Sum = "sum";
                const string Exit = "exit";
                
                DrawMenu();

                string userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case Sum:
                        Summarize(numbers);
                        break;

                    case Exit:
                        ExitProgramm(ref isWork);
                        break;

                    default:
                        AddNumbers(userInput, numbers);
                        break;
                }

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

        static void ExitProgramm(ref bool isWork)
        {
            Console.WriteLine("Досвидания!!!");
            Console.ReadKey();

            isWork = false;
        }

        static void Summarize(List<int> numbers)
        {
            int sum = 0;

            foreach(int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine("Сумма всех чисел равна - " + sum);
            Console.ReadKey();
        }

        static void AddNumbers(string userInput, List<int> numbers)
        {
            int number;

            if (int.TryParse(userInput, out number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз");
                Console.ReadKey();
            }
        }
    }
}
