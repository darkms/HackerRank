using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
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
            if (inputString.Length % 2 != 0)
            {
                Console.WriteLine("-1");
                return;
            }

            var left = inputString.Substring(0, inputString.Length / 2);
            var right = inputString.Substring(inputString.Length / 2);

            var leftExploded = ExplodeString(left);
            var rightExploded = ExplodeString(right);

            var changesRequired = 0;
            foreach (var key in rightExploded.Keys)
            {
                int leftValue;
                if (!leftExploded.TryGetValue(key, out leftValue))
                {
                    leftValue = 0;
                }

                var rightValue = rightExploded[key];

                var substracted = leftValue - rightValue;
                if (substracted < 0)
                    changesRequired += Math.Abs(substracted);
            }

            Console.WriteLine(changesRequired);
        }

        private static Dictionary<char, int> ExplodeString(string str)
        {
            var result = new Dictionary<char, int>();
            foreach (var ch in str)
            {
                if (!result.ContainsKey(ch))
                {
                    result[ch] = 0;
                }

                result[ch]++;
            }

            return result;
        }
    }
}