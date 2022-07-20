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
            string name = "Kozlov", surname = "Vlad";
            string buf;

            Console.WriteLine($"Имя - {name}, Фамилия - {surname}.");
            
            buf = name;
            name = surname;
            surname = buf;

            Console.WriteLine($"Имя - {name}, Фамилия - {surname}.");
        }
    }
}
