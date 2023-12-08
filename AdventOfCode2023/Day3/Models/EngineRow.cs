namespace AdventOfCode2023.Day3.Models
{
    public class EngineRow
    {
        public IEnumerable<PartNumber> PartNumbers { get; set; } = new List<PartNumber>();

        public IEnumerable<int> SymbolIndex { get; set; } = new List<int>();

        public EngineRow(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                if (Char.IsDigit(currentChar))
                {
                    var startIndex = i;
                    while (Char.IsDigit(currentChar) && i < input.Length - 1)
                    {
                        i++;
                        currentChar = input[i];
                    }
                    var endIndex = i;
                    var id = Int32.Parse(input.Substring(startIndex, endIndex - startIndex));
                    this.PartNumbers = this.PartNumbers.Append(new PartNumber
                    {
                        StartIndex = startIndex,
                        EndIndex = endIndex - 1,
                        Id = id
                    });
                }
                if (currentChar != '.')
                {
                    this.SymbolIndex = this.SymbolIndex.Append(i);
                }
            }
        }
    }
}
