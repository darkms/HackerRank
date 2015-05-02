using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangrams
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            DoTestCase();
        }

        private static void DoTestCase()
        {
            var inputString = Console.ReadLine();

            var hashSet = new HashSet<char>();
            foreach (var symbol in inputString)
            {
                if (hashSet.Count == 26)
                {
                    break;
                }

                var upper = char.ToUpper(symbol);
                if (upper >= 65 && upper <= 90)
                {
                    hashSet.Add(upper);
                }
            }

            if (hashSet.Count == 26)
            {
                Console.WriteLine("pangram");
            }
            else
            {
                Console.WriteLine("not pangram");
            }
        }
    }
}