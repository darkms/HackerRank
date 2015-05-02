using System;
using System.Linq;

namespace BiggerIsGreater
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
            var input = inputString.ToCharArray();

            LexHigher(input, input.Length - 1);

            var resultStr = new string(input);
            if (resultStr == inputString)
            {
                Console.WriteLine("no answer");
                return;
            }

            Console.WriteLine(resultStr);
        }

        private static bool LexHigher(char[] input, int rightBoundary, int bestKSoFar = -1, char bestCharSoFar = char.MaxValue)
        {
            if (rightBoundary >= input.Length)
            {
                return false;
            }

            // Go from right to left, char @ idx 0 can't be swapped
            for (var i = rightBoundary; i > 0; i--)
            {
                var right = input[i];

                // Step to the left while trying to get a char that is lexicographically higher
                for (var k = i - 1; k >= 0; k--)
                {
                    var left = input[k];

                    if (right > left)
                    {
                        // We don't have to compare input[i] for that attempt because if it was lower, we would've already tryed to swap with it
                        if ((k == bestKSoFar && right < bestCharSoFar) || (k > bestKSoFar))
                        {
                            if (!LexHigher(input, i - 1, k, right))
                            {
                                input[k] = right;
                                input[i] = left;
                                LexLowest(input, k + 1);
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private static void LexLowest(char[] input, int leftBoundary)
        {
            var sorted = input.Skip(leftBoundary).OrderBy(ch => ch);
            var idx = leftBoundary;
            foreach (var ch in sorted)
            {
                input[idx++] = ch;
            }
        }
    }
}