using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionOfArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers1 = { "1", "2", "1" };
            string[] numbers2 = { "3", "2" };
            List<string> unionNumbers = new List<string>();

            MergeArrays(unionNumbers, numbers1, numbers2);

            Draw(unionNumbers);
        }

        static void MergeArrays(List<string> unionNumbers, string[] array1, string[] array2)
        {
            List<string> tempNumbers = new List<string>(array1);

            foreach (string item in array2)
            {
                if (!tempNumbers.Contains(item))
                {
                    tempNumbers.Add(item);
                }
            }

            for (int i = 0; i < tempNumbers.Count; i++)
            {
                if (!unionNumbers.Contains(tempNumbers[i]))
                {
                    unionNumbers.Add(tempNumbers[i]);
                }
            }
        }

        static void Draw(List<string> list)
        {
            foreach (string item in list)
            {
                Console.Write(item + ' ');
            }
        }
    }
}
