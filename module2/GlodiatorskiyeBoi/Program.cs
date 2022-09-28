using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlodiatorskiyeBoi
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Fighter
    {
        protected string _name;
        protected int _health;
        protected int _damage;
        protected int _armor;
        public Random random = new Random();

        public Fighter(string name = "", int health = 0, int damage = 0, int armor = 0)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }

        public int TakeDamage()
        {
            return _damage; 
        }

        public void AcceptDamage(int damageDown)
        {
            damageDown -= (damageDown * _armor) / 100;
            _health -= damageDown;
        }
    }

    class Warrior : Fighter
    {
        private int _countCick = 0;

        public Warrior(string name) : base()
        {
            _name = name;
            _damage = random.Next(6,8);
            _health = random.Next(80, 100);
            _armor = 6;
        }

        new public int TakeDamage()
        {
            const int PunchesToCombo = 3;
            ++_countCick;

            if ((_countCick % PunchesToCombo) == 0)
            {
                TakeDamage();
            }

            return _damage;
        }
    }
}
