using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZnachVar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Kozlov";
            string surname = "Vlad";
            string auxiliaryVariable;

            Console.WriteLine($"Имя - {name}, Фамилия - {surname}.");

            auxiliaryVariable = name;
            name = surname;
            surname = auxiliaryVariable;

            Console.WriteLine($"Имя - {name}, Фамилия - {surname}.");
        }
    }
}
