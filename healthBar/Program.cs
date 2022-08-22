using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace healthBar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value;
            int maxValue = 10;
            int position;

            value = GetValue();
            position = GetPosition() - 1; 
            DrawBar(value, maxValue, position);
        }

        static int GetValue()
        {
            Console.Write("Введите значение жизней : ");
            int value = Convert.ToInt32(Console.ReadLine());
            return value;
        }

        static int GetPosition()
        {
            Console.Write("Введите позицию :");
            int position = Convert.ToInt32(Console.ReadLine());
            return position;
        }

        static void DrawBar(int value, int maxValue, int position, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            Console.SetCursorPosition(0, position);
            Console.Write("[");
            string bar = "";
            Console.BackgroundColor = color;
            
            for (int i = 0; i < value; i++)
            {
                bar += " ";
            }

            Console.Write(bar);
            Console.BackgroundColor = defaultColor;
            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += ' ';
            }
            
            Console.Write(bar + "]\n");
        }
    }
}
