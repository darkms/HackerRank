using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SherlockAndAnagrams
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfCases = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfCases; i++)
            {
                DoTestCase();
            }
        }

        private static bool Debug = false;

        private static void DoTestCase()
        {
            var numPairs = 0;
            var inputString = Console.ReadLine().Trim();

            // Go from left to right O(N)
            for (var leftStart = 0; leftStart < inputString.Length; leftStart++)
            {
                var leftContainer = new Container();
                var currentLength = 0;
                // Incrementing length O(N)
                while (inputString.Length > leftStart + ++currentLength)
                {
                    var newCharToLeft = inputString[leftStart + currentLength - 1];
                    leftContainer.AddChar(newCharToLeft);

                    // Start checking from the letter to the right
                    var rightContainer = new Container();
                    for (var i = 1; i <= currentLength; i++)
                    {
                        rightContainer.AddChar(inputString[leftStart + i]);
                    }

                    if (leftContainer.IsAnagram(rightContainer))
                    {
                        if (Debug)
                            Console.WriteLine("Pair at ({0}-{1},{2}-{3}) ('{4}' ~ '{5}')",
                                leftStart + 1,
                                leftStart + currentLength,
                                leftStart + 2,
                                leftStart + 1 + currentLength,
                                leftContainer,
                                rightContainer);

                        numPairs++;
                    }

                    for (var rightStart = leftStart + 2; rightStart < inputString.Length - currentLength + 1; rightStart++)
                    {
                        var newCharToRight = inputString[rightStart + currentLength - 1];
                        rightContainer.RemoveFirstChar();
                        rightContainer.AddChar(newCharToRight);

                        if (leftContainer.IsAnagram(rightContainer))
                        {
                            if (Debug)
                                Console.WriteLine("Pair at ({0}-{1},{2}-{3}) ('{4}' ~ '{5}')",
                                    leftStart + 1,
                                    leftStart + currentLength,
                                    rightStart + 1,
                                    rightStart + currentLength,
                                    leftContainer,
                                    rightContainer);

                            numPairs++;
                        }
                    }
                }
            }

            Console.WriteLine(numPairs);
        }

        private class Container
        {
            public Container()
            {
                for (var i = 0; i < 26; i++)
                {
                    var ch = (char)(97 + i);
                    _charCounts[ch] = 0;
                }
            }

            public void AddChar(char ch)
            {
                _container.Enqueue(ch);
                _charCounts[ch]++;
            }

            public void RemoveFirstChar()
            {
                if (_container.Count == 0)
                    return;

                var ch = _container.Dequeue();
                _charCounts[ch]--;
            }

            public bool IsAnagram(Container anotherContainer)
            {
                return this._charCounts.All(pair => anotherContainer._charCounts[pair.Key] == pair.Value);
            }

            public override string ToString()
            {
                return new string(_container.ToArray());
            }

            private long TotalValue { get; set; }

            private Queue<char> _container = new Queue<char>();
            private Dictionary<char, int> _charCounts = new Dictionary<char, int>(26);
        }

        static Program()
        {
            Debug = false;
        }
    }
}