namespace AdventOfCode2023.Day3.Models
{
    public class PartNumber
    {
        public int StartIndex { get; set; }

        public int EndIndex { get; set; }

        public int Id { get; set; }

        public bool IsValid(IEnumerable<EngineRow> neighbours)
        {
            return neighbours.Any(neighbour =>
                neighbour.SymbolIndex.Any(symbolIndex =>
                    symbolIndex >= this.StartIndex - 1 &&
                    symbolIndex <= this.EndIndex + 1));
        }
    }
}
