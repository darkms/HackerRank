using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyString
{
    public static class Program
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
            var result = "Funny";
            for (var i = 1; i < inputString.Length; i++)
            {
                var left = Math.Abs(inputString[i] - inputString[i - 1]);
                var right = Math.Abs(inputString[inputString.Length - i - 1] - inputString[inputString.Length - i]);
                if (left != right)
                {
                    result = "Not Funny";
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}