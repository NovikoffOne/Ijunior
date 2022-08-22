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
            int value = 4;
            int maxValue = 10;
            DrawBar(value, maxValue);
        }

        static void DrawBar(int value, int maxValue, ConsoleColor color = ConsoleColor.Red)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            Console.SetCursorPosition(0, 0);
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
            
            Console.Write(bar + ']');
        }
    }
}
