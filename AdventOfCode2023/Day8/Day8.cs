using AdventOfCode2023.Day8.Models;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023.Day8
{
    public static class Day8
    {
        public static int Part1()
        {
            var input = Helpers.FileHelpers.ParseInputAsString("Day8/day8.txt").ToList();
            return Part1(input);
        }

        public static int Part1(IEnumerable<string> input)
        {

            var nodes = input.Skip(2).Select(ParseNode).ToDictionary(node => node.Key);
            var steps = input.First();
            var currentNode = nodes["AAA"];
            return TraverseNodes(nodes, steps, "AAA", (s) => s.EndsWith("ZZZ"));
        }

        public static long Part2()
        {
            var input = FileHelpers.ParseInputAsString("Day8/day8.txt").ToList();
            return Part2(input);
        }

        public static long Part2(IEnumerable<string> input)
        {

            var nodes = input.Skip(2).Select(ParseNode).ToDictionary(node => node.Key);
            var steps = input.First();
            var startNodes = nodes.Where(n => n.Key.EndsWith("A"));
            var cycleLengths = startNodes.Select(s => TraverseNodes(nodes, steps, s.Key, (s) => s.EndsWith("Z"))).Select(s => (long)s).ToList();
            return MathHelpers.LeastCommonMultiple(cycleLengths);

        }

        private static int TraverseNodes(Dictionary<string, Node> nodes, string steps, string start, Func<string, bool> end)
        {
            var currentNode = nodes[start];
            var totalStep = 0;

            while (!end(currentNode.Key))
            {
                var action = steps[totalStep % steps.Length];
                if (action == 'L')
                {
                    currentNode = nodes[currentNode.Left];
                }
                else
                {
                    currentNode = nodes[currentNode.Right];
                }
                totalStep++;
            }
            return totalStep;
        }

        public static Node ParseNode(string line)
        {
            var parts = line.Split(' ');
            var key = parts[0];
            var left = parts[2].Substring(1, 3).Trim();
            var right = parts[3].Substring(0, 3).Trim();
            var node = new Node()
            {
                Key = key,
                Left = left,
                Right = right
            };

            return node;
        }
    }
}
