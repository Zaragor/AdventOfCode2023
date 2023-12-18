using AdventOfCode2023.Day15.Models;

namespace AdventOfCode2023.Day15
{
    public class Day15
    {
        public long Part1()
        {
            var input = File.ReadAllText("Day15/day15.txt");
            return this.Part1(input);
        }

        public long Part1(string input)
        {
            return input.Split(',').Select(Hash).Sum();
        }

        public long Part2()
        {
            var input = File.ReadAllText("Day15/day15.txt");
            return this.Part2(input);
        }

        public long Part2(string input)
        {
            var boxes = Enumerable.Range(0, 256).Select(i => new List<Lens>()).ToArray();
            var steps = input.Split(',');
            for (var i = 0; i < steps.Length; i++)
            {
                var step = steps[i];
                var label = new string(step.TakeWhile(c => c != '-' && c != '=').ToArray());
                var box = boxes[Hash(label)];
                var existing = box.FirstOrDefault(l => l.Label == label);
                if (step.ElementAt(label.Length) == '=')
                {
                    var focus = int.Parse(step.Substring(step.IndexOf('=') + 1));
                    if (existing != default)
                    {
                        existing.Focus = focus;
                    }
                    else
                    {
                        box.Add(new Lens(label, focus));
                    }
                }
                else
                {
                    if (existing != default)
                    {
                        box.Remove(existing);
                    }
                }
            }

            var total = 0L;
            for (var i = 0; i < boxes.Length; i++)
            {
                var box = boxes[i];
                var boxTotal = CalculateBox(i, box);
                total += boxTotal;
            }

            return total;
        }

        internal long CalculateBox(int index, List<Lens> box)
        {
            var total = 0;
            for (var i = 0; i < box.Count; i++)
            {
                var item = box[i];
                var lensTotal = (index + 1) * (i + 1) * item.Focus;
                total += lensTotal;
            }
            return total;
        }

        // We rely on the fact the the bottom half of UTF-8 is the same as ASCII, and that an 8 bit byte will automatically do the modulo 256 for us via integer overflow.
        public int Hash(string input)
        {
            byte hash = 0;
            foreach (var c in input)
            {
                hash += (byte)c;
                hash *= 17;
            }
            return hash;
        }

    }
}
