using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternatingCharacters
{
    class Program
    {
        public static void Main(string[] args)
        {
            var numberOfCases = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfCases; i++)
            {
                DoTestCase();
            }
        }

        private static void DoTestCase()
        {
            var inputString = Console.ReadLine();
            var result = 0;

            inputString.Aggregate((i1, i2) =>
            {
                if (i1 == i2)
                    result++;
                return i2;
            });

            Console.WriteLine(result);
        }
    }
}
