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
            int picturesInARow = 3;
            int remainderPictures = allPictures % picturesInARow;
            int filledRows = allPictures / picturesInARow;

            Console.WriteLine($"Количество заполненых рядов {filledRows}");
            Console.WriteLine($"Картинок сверх меры : {remainderPictures}");
        }
    }
}
