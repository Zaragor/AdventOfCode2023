namespace AdventOfCode2023.Day5.Models
{
    public class Map
    {
        public string Key { get; set; }

        public List<Shift> Shifts { get; set; } = new List<Shift>();
    }
}
