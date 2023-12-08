namespace AdventOfCode2023.Day2.Models
{
    public class Roll
    {
        public Roll(string roll)
        {
            if (roll.Contains("red"))
            {
                this.Color = Color.Red;
            }
            else if (roll.Contains("green"))
            {
                this.Color = Color.Green;
            }
            else if (roll.Contains("blue"))
            {
                this.Color = Color.Blue;
            }
            else
            {
                throw new ArgumentException("Invalid color");
            }

            var count = roll.Substring(0, roll.IndexOf(' '));
            this.Count = int.Parse(count);
        }

        public bool IsValid(IEnumerable<(Color, int)> colors)
        {
            var color = colors.FirstOrDefault(color => color.Item1 == this.Color);
            return this.Count <= color.Item2;
        }

        public Color Color;
        public int Count;
    }
}
