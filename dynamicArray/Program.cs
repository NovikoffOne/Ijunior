using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string userInput;
            int userNumber;
            int sum;
            int[] arrayNumber = new int[0];

            while (isWork)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Введите число, что бы добавить его в массив.");
                Console.WriteLine("Введите \"sum\" чтобы получить сумму всех чисел в массиве.");
                Console.WriteLine("Введите \"exit\" для выхода.");
                Console.SetCursorPosition(0, 0);
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "sum":
                        sum = 0;
                        
                        for (int i = 0; i < arrayNumber.Length; i++)
                        {
                            sum += arrayNumber[i];
                        }

                        Console.WriteLine("Сумма равна - " + sum);
                        Console.ReadKey();
                        break;

                    case "exit":
                        Console.WriteLine("Увидимся)");
                        isWork = false;
                        break;

                    default:
                        userNumber = Convert.ToInt32(userInput);
                        int[] tempArrayNumber = new int[arrayNumber.Length + 1];
                        
                        for (int i = 0; i < arrayNumber.Length; i++)
                        {
                            tempArrayNumber[i] = arrayNumber[i];
                        }
                        tempArrayNumber[tempArrayNumber.Length - 1] = userNumber;
                        arrayNumber = tempArrayNumber;
                        break;
                }
                
                Console.Clear();
            }
        }
    }
}
