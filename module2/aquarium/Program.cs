﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium(3);
            bool isWork = true;

            while (isWork)
            {
                const string CommandAddFish = "1";
                const string CommandDeleteFish = "2";
                const string CommandExit = "3";

                aquarium.DrawFishes();

                Console.WriteLine(
                    $"{CommandAddFish} - Добавить рыбку.\n" +
                    $"{CommandDeleteFish} - Убрать рыбку.\n" +
                    $"{CommandExit} - Выход.\n" +
                    $"Или нажмите Enter, чтобы продолжить..."
                    );
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddFish:
                        aquarium.AddFish();
                        break;

                    case CommandDeleteFish:
                        aquarium.DeleteFish();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        break;
                }

                aquarium.Live();
                Console.Clear();
            }

        }        
    }

    public static class UserUtils
    {
        public static int ReadInt()
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int number);

            if (isNumber)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Попробуйте еще раз!");
                return number = 0;
            }
        }
    }

    class Aquarium
    {
        private int _maxFish;
        private List<Fish> _fishes;

        public Aquarium(int maxFish)
        {
            _maxFish = maxFish;
            _fishes = new List<Fish> { new Fish("Немо", "Рыба-Клоун"), new Fish("Дори", "Хирурург-Королевский"), new Fish("Сэм", "Акула") };
        }

        public void DrawFishes()
        {
            int index = 0;
            string isLive;

            Console.SetCursorPosition(0, 20);

            foreach (var fish in _fishes)
            {
                if (fish.isLive)
                {
                    isLive = "Живая";
                }
                else
                {
                    isLive = "Плавает брюхом к верху";
                }

                Console.WriteLine($"{index}.{fish.Name} вид: {fish.TypeFish} ({isLive}).");
                index++;
            }

            Console.SetCursorPosition(0, 0);
        }

        public void AddFish()
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();

            if (_fishes.Count <= _maxFish)
            {
                _fishes.Add(new Fish(name, type));
                Console.WriteLine($"рыбка {name} - {type}, запущена в акквариум.");
            }
            else
            {
                Console.WriteLine("Акквариум уже полный!");
            }
        }

        public void DeleteFish()
        {
            Console.WriteLine("Введите номер рыбки : ");
            int userInput = UserUtils.ReadInt();

            if(userInput > _fishes.Count - 1 || userInput < 0)
            {
                Console.WriteLine("Попробуйте еще раз...");
            }
            else
            {
                Console.WriteLine($"Вы убрали рыбку {_fishes[userInput]} из аквариума.");
                _fishes.RemoveAt(userInput);
            }
        }

        public void Live()
        {
           foreach(var fish in _fishes)
           {
                fish.AgeFish();
                fish.TestLive();
           }
        }
    }

    class Fish
    {
        public string TypeFish { get; private set; }
        public string Name { get; private set; }
        public int Old { get; private set; }
        public bool isLive { get; private set; }
        private int _maxOld;

        public Fish(string name = "нонейм", string type = "неопределено", int maxOld = 5)
        {
            Name = name;
            TypeFish = type;
            Old = 0;
            isLive = true;
            _maxOld = maxOld;
        }

        public void AgeFish()
        {
            Old += 1;
        }

        public void TestLive()
        {
            if (Old > _maxOld)
            {
                isLive = false;
            }
        }
    }
}
