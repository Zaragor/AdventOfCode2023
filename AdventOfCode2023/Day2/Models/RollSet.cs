namespace AdventOfCode2023.Day2.Models
{
    public class RollSet
    {
        public RollSet(string roll)
        {
            var rolls = roll.Split(',').Select(roll => roll.Trim());
            this.Rolls = rolls.Select(roll => new Roll(roll));
        }
        public IEnumerable<Roll> Rolls { get; set; }
    }
}
