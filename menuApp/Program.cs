using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menuApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            string firstName;
            string lastName;
            string password;
            bool isWork = true;

            

            while (isWork)
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "указать имя":
                        firstName = Console.ReadLine();
                        break;
                    case "указать фамилию":
                        lastName = Console.ReadLine();
                        break;
                    case "установить пароль":
                        password = Console.ReadLine();
                        break;
                    case "сменить цвет текста":
                        Console.Write("выберите цвет : ");
                        string textColor = Console.ReadLine();

                        switch (textColor)
                        {
                            case ("зеленый"):
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case ("красный"):
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case ("синий"):
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case ("желтый"):
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case ("стандартный"):
                                Console.ResetColor();
                                break;
                        }

                        break;
                    case ("изменить размер"):
                        string options = Console.ReadLine();

                        switch (options)
                        {
                            case ("ширина"):
                                int windowWidth = Convert.ToInt32(Console.ReadLine());
                                Console.WindowWidth = windowWidth;
                                break;
                            case ("высота"):
                                int windowHeight = Convert.ToInt32(Console.ReadLine());
                                Console.WindowHeight = windowHeight;
                                break;
                        }

                        break;

                    case ("help"):
                        Console.WriteLine("указать имя\nуказать фамилию\nустановить пароль\nсменить цвет текста\nизменить размер");
                        break;
                }
            }
        }
    }
}