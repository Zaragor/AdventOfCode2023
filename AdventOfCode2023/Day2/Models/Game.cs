namespace AdventOfCode2023.Day2.Models
{
    public class Game
    {
        public Game(string line)
        {
            var endOfId = line.IndexOf(':');
            var id = line.Substring(5, endOfId - 5);
            this.Id = int.Parse(id);
            var rollSet = line.Substring(endOfId + 1).Split(';').Select(roll => roll.Trim());
            this.RollSet = rollSet.Select(rollSet => new RollSet(rollSet));
        }

        public int Id { get; set; }
        public IEnumerable<RollSet> RollSet { get; set; }

        public int MinimumColors()
        {
            var red = this.RollSet.SelectMany(r => r.Rolls).Where(roll => roll.Color == Color.Red).Max(roll => roll.Count);
            var green = this.RollSet.SelectMany(r => r.Rolls).Where(roll => roll.Color == Color.Green).Max(roll => roll.Count);
            var blue = this.RollSet.SelectMany(r => r.Rolls).Where(roll => roll.Color == Color.Blue).Max(roll => roll.Count);
            return red * green * blue;
        }
    }
}
