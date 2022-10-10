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
        public string Class { get; protected set; }
        public int Health { get; protected set; }
        
        protected int CountKick;
        protected int Damage;
        protected int Armor;
        protected int MinDamage;
        protected int MaxDamage;
        protected Random Random = new Random();
        protected int HitsToCombos;
        
        public Fighter(string name = "")
        {
            Class = name;
            CountKick = 0;
        }

        public virtual int GiveDamage()
        {
            Damage = Random.Next(MinDamage, MaxDamage);
            Console.WriteLine($"{Class} наносит {Damage} урона...");

            return Damage;
        }

        public virtual void TakeDamage(int damage)
        {
            damage = CalculateNetDamage(damage);
            Health -= damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine($" Class - {Class} | HP - {Health} | ARM - {Armor} | DMG - {MinDamage}-{MaxDamage}");
        }

        protected int CalculateNetDamage(int damage)
        {
            double tempDamage = Convert.ToDouble(damage);
            tempDamage *= (double)Armor / 100;
            damage = Convert.ToInt32(Convert.ToDouble(damage) - tempDamage);
            
            return damage;
        }
    }

    class Paladin : Fighter
    {
        public Paladin()
        {
            Health = 100;
            Class = "Пладин";
            MinDamage = 4;
            MaxDamage = 8;
            Armor = 50;
            HitsToCombos = 3;
        }

        public override int GiveDamage()
        {
            Damage = Random.Next(MinDamage, MaxDamage);
            CountKick++;

            MakeCombo();

            Console.WriteLine($"{Class} наносит {Damage} урона...");

            return Damage;
        }

        private void MakeCombo()
        {
            if ((CountKick % HitsToCombos) == 0)
            {
                Damage += Random.Next(MinDamage, MaxDamage);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Паладин наносит два удара!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    class Warrior : Fighter
    {
        private int _factorBonusDamage = 2;

        public Warrior()
        {
            Health = 110;
            Class = "Воин";
            MinDamage = 6;
            MaxDamage = 10;
            Armor = 30;
            HitsToCombos = 5;
        }

        public override int GiveDamage()
        {
            CountKick++;
            Damage = Random.Next(MinDamage, MaxDamage);

            if (CountKick % HitsToCombos == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Воин выждал момент и наносит двойной урон!");
                Console.ForegroundColor = ConsoleColor.White;
                Damage *= _factorBonusDamage;
            }

            Console.WriteLine($"{Class} наносит {Damage} урона...");

            return Damage;
        }
    }

    class Pathfinder : Fighter
    {
        private int _dodgeСhance;

        public Pathfinder()
        {
            Health = 150;
            Class = "Следопыт";
            MinDamage = 4;
            MaxDamage = 6;
            Armor = 30;
            HitsToCombos = 3;
            _dodgeСhance = 30;
        }

        public override void TakeDamage(int damage)
        {
            int dodge = Random.Next(0, 100);

            if(dodge > _dodgeСhance)
            {
                damage = CalculateNetDamage(damage);
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
        private int _minRageDamage = 9;
        private int _maxRageDamage = 13;
        private int _rageHealing = 2;

        public Barbarian()
        {
            Health = 90;
            Class = "Варвар";
            MinDamage = 7;
            MaxDamage = 11;
            Armor = 10;
        }

        public override void TakeDamage(int damage)
        {
            damage = CalculateNetDamage(damage);
            Health -= damage;

            GoRage();
        }

        public void GoRage()
        {
            if (Health < _rageCounter)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Варвар в ярости!");
                Console.ForegroundColor = ConsoleColor.White;

                Health += _rageHealing;
                MinDamage = _minRageDamage;
                MaxDamage = _maxRageDamage;
            }
        }
    }

    class Monk : Fighter
    {
        private int _hitChance = 80;
        private int _chiShieldChance = 25;
        private int _factorBonusDamage = 2;

        public Monk()
        {
            Health = 120;
            Class = "Монах";
            MinDamage = 4;
            MaxDamage = 5;
            Armor = 5;
            HitsToCombos = 3;
        }

        public override int GiveDamage()
        {
            Damage = Random.Next(MinDamage, MaxDamage);

            ApplyPreciseBlow();
            
            Console.WriteLine($"{Class} наносит {Damage} урона...");

            return Damage;
        }

        public override void TakeDamage(int damage)
        {
            int chance = Random.Next(0, 100);

            if (chance <= _chiShieldChance)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Монах собрал энергию ЦИ и защитился от удара!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                damage = CalculateNetDamage(damage);
                Health -= damage;
            }
        }

        public void ApplyPreciseBlow() 
        {
            int chance = Random.Next(0, 100);

            if((CountKick % HitsToCombos == 0) && chance < _hitChance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Монах читает энергию ЦИ и наносит точный удар!");
                Console.ForegroundColor = ConsoleColor.White;

                Damage *= _factorBonusDamage;
            }
        }
    }

    class Arena
    {
        private Fighter _fighter1;
        private Fighter _fighter2;

        public Arena()
        {
            _fighter1 = ChooseFighter();
            _fighter1.ShowInfo();
            _fighter2 = ChooseFighter();
            _fighter2.ShowInfo();

            StartFight();
        }

        private void StartFight()
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

            List<string> fightersClass = new List<string> { "Паладин", "Воин", "Следопыт", "Варвар", "Монах" };

            int index = 0;

            Console.WriteLine("Выберите бойца : ");

            foreach (string fighter in fightersClass)
            {
                Console.WriteLine($"{index} - {fighter}");
                index++;
            }

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case CommandCreatePaladin:
                    return new Paladin();

                case CommandCreateWarrior:
                    return new Warrior();

                case CommandCreatePathfinder:
                    return new Pathfinder();

                case CommandCreateBarbarian:
                    return new Barbarian();

                case CommandCreateMonk:
                    return new Monk();

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
                Console.WriteLine($"Победил {_fighter2.Class}!");
                _fighter2.ShowInfo();
                Console.ForegroundColor = colorDefault;
            }
            else if (_fighter1.Health > 0 && _fighter2.Health <= 0)
            {
                Console.ForegroundColor = colorWin;
                Console.WriteLine($"Победил {_fighter1.Class}!");
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
