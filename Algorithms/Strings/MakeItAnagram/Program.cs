using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeItAnagram
{
    class Program
    {
        public static void Main(string[] args)
        {
            DoTestCase();
        }

        private static void DoTestCase()
        {
            var left = Console.ReadLine();
            var right = Console.ReadLine();

            var leftExploded = ExplodeString(left);
            var rightExploded = ExplodeString(right);

            var changesRequired = 0;
            var allKeys = leftExploded.Keys.Union(rightExploded.Keys).Distinct();
            foreach (var key in allKeys)
            {
                int leftValue;
                if (!leftExploded.TryGetValue(key, out leftValue))
                {
                    leftValue = 0;
                }

                int rightValue;
                if (!rightExploded.TryGetValue(key, out rightValue))
                {
                    rightValue = 0;
                }

                var substracted = leftValue - rightValue;
                if (substracted != 0)
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
