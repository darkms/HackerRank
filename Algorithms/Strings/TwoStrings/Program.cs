using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStrings
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
            var left = Console.ReadLine();
            var right = Console.ReadLine();

            var leftExploded = new Dictionary<char, bool>();
            foreach (var ch in left)
            {
                leftExploded[ch] = true;
            }

            if (right.Any(ch => leftExploded.ContainsKey(ch)))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
