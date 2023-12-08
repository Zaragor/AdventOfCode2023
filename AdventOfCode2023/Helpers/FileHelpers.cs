namespace AdventOfCode2023.Helpers
{
    internal class FileHelpers
    {
        public static IEnumerable<string> ParseInputAsString(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        yield return reader.ReadLine();
                    }
                }
            }
        }
    }
}
