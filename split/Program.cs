using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string randomText = "Привет как дела так давно не виделись";
            char separetion = ' ';
            string[] wordArray = randomText.Split(separetion);
            
            foreach (string word in wordArray)
            {
                Console.WriteLine(word);
            }
        }
    }
}
