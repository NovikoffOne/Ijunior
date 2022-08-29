using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queueToTheStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int check = 0;
            int[] numbers = { 1699, 4999, 2499, 1999, 6899 };
            Queue<int> purchaseAmount = new Queue<int>(numbers);

            ServeAClient(check, purchaseAmount);
        }

        static void ServeAClient(int check, Queue<int> shoppingList)
        {
            for (int i = shoppingList.Count; i > 0; i--)
            {
                check += shoppingList.Dequeue();
                Console.WriteLine("Счет - " + check);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
