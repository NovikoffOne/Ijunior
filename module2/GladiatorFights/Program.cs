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
            const string CommandFight = "1";
            const string CommandExit = "2";
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine
                    ($"{CommandFight} - Бой!\n" +
                    $"{CommandExit} - Выход!");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandFight:
                        Arena arena = new Arena();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Fighter
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public string Class { get; protected set; }
        protected int _countKick;
        protected int _damage;
        protected int _armor;
        protected Random random = new Random();
        protected int _minDamage;
        protected int _maxDamage;
        protected int _hitsToCombos;

        public Fighter(string name = "")
        {
            Name = name;
            _countKick = 0;
        }

        public virtual int GiveDamage()
        {
            _damage = random.Next(_minDamage, _maxDamage);
            Console.WriteLine($"{Name} наносит {_damage} урона...");

            return _damage;
        }

        public virtual void TakeDamage(int damage)
        {
            damage = ArmorClass(damage);
            Health -= damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name - {Name} | Class - {Class} | HP - {Health} | ARM - {_armor} | DMG - {_minDamage}-{_maxDamage}");
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
            Name = name;
            Health = 100;
            Class = "Пладин";
            _minDamage = 4;
            _maxDamage = 8;
            _armor = 50;
            _hitsToCombos = 3;
        }

        public override int GiveDamage()
        {
            _damage = random.Next(_minDamage, _maxDamage);
            _countKick++;

            MakeCombo();

            Console.WriteLine($"{Name} наносит {_damage} урона...");

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
            Name = name;
            Health = 110;
            Class = "Воин";
            _minDamage = 6;
            _maxDamage = 10;
            _armor = 30;
            _hitsToCombos = 5;
        }

        public override int GiveDamage()
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

            Console.WriteLine($"{Name} наносит {_damage} урона...");

            return _damage;
        }
    }

    class Pathfinder : Fighter
    {
        private int _dodgeСhance;

        public Pathfinder(string name)
        {
            Name = name;
            Health = 150;
            Class = "Следопыт";
            _minDamage = 4;
            _maxDamage = 6;
            _armor = 30;
            _hitsToCombos = 3;
            _dodgeСhance = 30;
        }

        public override void TakeDamage(int damage)
        {
            int dodge = random.Next(0, 100);
            if(dodge > _dodgeСhance)
            {
                damage = ArmorClass(damage);
                Health -= damage;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Промах!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    class Barbarian : Fighter
    {
        private int _rageCounter = 35;

        public Barbarian(string name)
        {
            Name = name;
            Health = 90;
            Class = "Варвар";
            _minDamage = 7;
            _maxDamage = 11;
            _armor = 10;
        }

        public override void TakeDamage(int damage)
        {
            damage = ArmorClass(damage);
            Health -= damage;

            Rage();
        }

        public void Rage()
        {
            if (Health < _rageCounter)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Варвар в ярости!");
                Console.ForegroundColor = ConsoleColor.White;

                Health += 2;
                _minDamage = 9;
                _maxDamage = 13;
            }
        }
    }

    class Monk : Fighter
    {
        private int _hitChance = 80;
        private int _chiShieldChance = 25; 

        public Monk(string name)
        {
            Name = name;
            Health = 120;
            Class = "Монах";
            _minDamage = 4;
            _maxDamage = 5;
            _armor = 5;
            _hitsToCombos = 3;
        }

        public override int GiveDamage()
        {
            _damage = random.Next(_minDamage, _maxDamage);

            StrikeQi();
            
            Console.WriteLine($"{Name} наносит {_damage} урона...");

            return _damage;
        }

        public override void TakeDamage(int damage)
        {
            int chance = random.Next(0, 100);

            if (chance <= _chiShieldChance)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Монах собрал энергию ЦИ и защитился от удара!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                damage = ArmorClass(damage);
                Health -= damage;
            }
        }

        public void StrikeQi() 
        {
            int chance = random.Next(0, 100);

            if((_countKick % _hitsToCombos == 0) && chance < _hitChance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Монах читает энергию ЦИ и наносит точный удар!");
                Console.ForegroundColor = ConsoleColor.White;

                _damage *= 2;
            }
        }
    }

    class Arena
    {

        private List<string> _fighters = new List<string> { "Паладин", "Воин", "Следопыт", "Варвар", "Монах" };
        private Fighter _fighter1;
        private Fighter _fighter2;

        public void NewFight()
        {
            _fighter1 = ChooseFighter();
            _fighter1.ShowInfo();
            _fighter2 = ChooseFighter();
            _fighter2.ShowInfo();

            Battle();
        }

        private void Battle()
        {
            int round = 1;

            while (_fighter1.Health > 0 && _fighter2.Health > 0)
            {
                Console.WriteLine($"Round {round}");

                _fighter2.TakeDamage(_fighter1.GiveDamage());
                _fighter2.ShowInfo();
                _fighter1.TakeDamage(_fighter2.GiveDamage());
                _fighter1.ShowInfo();
                
                round++;
                Console.WriteLine();
            }

            ShowWinner();
        }

        private Fighter ChooseFighter()
        {
            const string CommandCreatePaladin = "0";
            const string CommandCreateWarrior = "1";
            const string CommandCreatePathfinder = "2";
            const string CommandCreateBarbarian = "3";
            const string CommandCreateMonk = "4";

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

                case CommandCreatePathfinder:
                    return new Pathfinder(userName);

                case CommandCreateBarbarian:
                    return new Barbarian(userName);

                case CommandCreateMonk:
                    return new Monk(userName);

                default:
                    Console.WriteLine("Что то пошло не так!");
                    return null;
            }
        }

        private void ShowWinner()
        {
            ConsoleColor colorWin = ConsoleColor.Green;
            ConsoleColor colorDefault = ConsoleColor.White;
            ConsoleColor consoleDraw = ConsoleColor.Yellow;

            if (_fighter2.Health > 0 && _fighter1.Health <= 0)
            {
                Console.ForegroundColor = colorWin;
                Console.WriteLine($"Победил {_fighter2.Name}!");
                _fighter2.ShowInfo();
                Console.ForegroundColor = colorDefault;
            }
            else if (_fighter1.Health > 0 && _fighter2.Health <= 0)
            {
                Console.ForegroundColor = colorWin;
                Console.WriteLine($"Победил {_fighter1.Name}!");
                _fighter1.ShowInfo();
                Console.ForegroundColor = colorDefault;
            }
            else if (_fighter2.Health <= 0 && _fighter1.Health <= 0)
            {
                Console.ForegroundColor = consoleDraw;
                Console.WriteLine($"Победителей нет!\nНичья!!!");
                Console.ForegroundColor = colorDefault;
            }
        }
    }
}
