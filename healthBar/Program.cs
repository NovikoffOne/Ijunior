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
            int value = 10;
            int maxValue = 10;
            DrawBar(value, maxValue);
        }

        static void DrawBar(int value, int maxValue, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = color;
            Console.Write("[");
            for (int i = 0; i < value; i++)
            {
                Console.Write('#');
            }
            Console.BackgroundColor = defaultColor;
            Console.SetCursorPosition(value, 0);
            for (int i = value; i < maxValue; i++)
            {
                if (i != maxValue - 1)
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.Write(" " + ']');
                }
                
            }

        }
    }
}
