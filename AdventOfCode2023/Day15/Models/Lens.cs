namespace AdventOfCode2023.Day15.Models
{
    internal class Lens
    {
        public Lens(string label, int focus)
        {
            Label = label;
            Focus = focus;
        }

        public string Label { get; set; }

        public int Focus { get; set; }
    }
}
