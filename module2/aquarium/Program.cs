using System;
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
                return ReadInt();
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes;
        private int _maxFish;

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
                if (fish.IsLive)
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
            if (_fishes.Count <= _maxFish)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

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
                fish.AddYear();
           }
        }
    }

    class Fish
    {
        private int _maxOld;

        public string TypeFish { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsLive
        {
            get
            {
                return Age <= _maxOld;
            }
            set
            {

            }
        }

        public Fish(string name = "нонейм", string type = "неопределено", int maxOld = 5)
        {
            Name = name;
            IsLive = true;
            TypeFish = type;
            Age = 0;
            _maxOld = maxOld;
        }

        public void AddYear()
        {
            Age += 1;
        }
    }
}
