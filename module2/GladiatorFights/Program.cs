using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatorFights
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();

            arena.Battle();
        }
    }

    class Fighter
    {
        protected string _name;
        public int _health; // закрыть
        protected int _damage;
        protected int _armor;
        protected Random random = new Random();
        protected int _minDamage;
        protected int _maxDamage;
        public int _countKick = 0; // закрыть
        protected int _hitsToCombos;

        public Fighter(string name = "")
        {
            _name = name;
        }

        public int GiveDamage()
        {
            _damage = random.Next(_minDamage, _maxDamage);
            return _damage;
        }

        public void TakeDamage(int damage)
        {
            ArmorClass(damage);
            _health -= damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {_name} | HP - {_health} | ARM - {_armor} | DMG - {_minDamage}-{_maxDamage}");
        }

        protected int ArmorClass(int damage)
        {
            double tempDamage = Convert.ToDouble(damage);
            tempDamage *= (double)_armor / 100;
            damage = Convert.ToInt32(Convert.ToDouble(damage) - tempDamage);
            return damage;
        }
    }

    class Paladin : Fighter
    {
        public Paladin(string name)
        {
            _name = name;
            _minDamage = 4;
            _maxDamage = 8;
            _armor = 50;
            _health = 100;
            _hitsToCombos = 3;
        }

        public new int GiveDamage()
        {
            _damage = random.Next(_minDamage, _maxDamage);

            _countKick++;

            MakeCombo();

            Console.WriteLine($"{_name} наносит {_damage} урона...");

            return _damage;
        }

        private void MakeCombo()
        {
            if ((_countKick % _hitsToCombos) == 0)
            {
                _damage += random.Next(_minDamage, _maxDamage);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Паладин наносит два удара!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    class Warrior : Fighter
    {
        public Warrior(string name)
        {
            _name = name;
            _minDamage = 6;
            _maxDamage = 11;
            _armor = 30;
            _health = 120;
            _hitsToCombos = 5;
        }

        public new int GiveDamage()
        {
            _countKick++;
            _damage = random.Next(_minDamage, _maxDamage);


            if (_countKick % _hitsToCombos == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Воин выждал момент и наносит двойной урон!");
                Console.ForegroundColor = ConsoleColor.White;
                _damage *= 2;
            }

            Console.WriteLine($"{_name} наносит {_damage} урона...");

            return _damage;
        }
    }

    class Arena
    {

        private List<string> _fighters = new List<string> { "Паладин", "Воин", "Следопыт", "Варвар", "Монах" };
        private Fighter _fighter1;
        private Fighter _fighter2;

        public Arena()
        {
            _fighter1 = ChooseFighter();
            _fighter1.ShowInfo();
            _fighter2 = ChooseFighter();
            _fighter2.ShowInfo();
        }

        public void Battle()
        {
            while (_fighter1._health > 0 && _fighter2._health > 0)
            {
                int tempDamage = 0;
                tempDamage = _fighter1.GiveDamage();
                _fighter2.TakeDamage(tempDamage);
                _fighter2.ShowInfo();
                tempDamage = _fighter2.GiveDamage();
                _fighter1.TakeDamage(tempDamage);
                _fighter1.ShowInfo();
                Console.WriteLine();
            }
        }

        private Fighter ChooseFighter()
        {
            const string CommandCreatePaladin = "0";
            const string CommandCreateWarrior = "1";
            //const string CommandCreate;
            //const string CommandCreate;
            //const string CommandCreate;

            int index = 0;

            Console.WriteLine("Выберите бойца : ");

            foreach (string fighter in _fighters)
            {
                Console.WriteLine($"{index} - {fighter}");
                index++;
            }

            string userInput = Console.ReadLine();

            Console.Write("Введите имя : ");
            string userName = Console.ReadLine();

            switch (userInput)
            {
                case CommandCreatePaladin:
                    return new Paladin(userName);

                case CommandCreateWarrior:
                    return new Warrior(userName);

                default:
                    Console.WriteLine("Что то пошло не так!");
                    return null;
            }
        }
    }
}
