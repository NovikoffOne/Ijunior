using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int allPictures = 52;
            int rowPictures = 3;
            int remainderPictures = allPictures % rowPictures;
            int printRow = allPictures / rowPictures;

            Console.WriteLine($"Количество заполненых рядов {printRow}");
            Console.WriteLine($"Картинок сверх меры : {remainderPictures}");
        }
    }
}
