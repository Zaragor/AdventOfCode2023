namespace AdventOfCode2023.Day5.Models
{
    public class Shift
    {
        public Int64 Source { get; set; }

        public Int64 SourceEnd
        {
            get
            {
                return Source + Distance;
            }
        }

        public Int64 Destination { get; set; }

        public Int64 ShiftAmount
        {
            get
            {
                return Destination - Source;
            }
        }

        public Int64 Distance { get; set; }

        public bool In((long start, long end) range)
        {
            var startInRange = this.Source <= range.start && this.SourceEnd >= range.start;
            var endInRange = this.Source <= range.end && this.SourceEnd >= range.end;
            var encompassed = this.Source >= range.start && this.SourceEnd <= range.end;

            return startInRange || endInRange || encompassed;
        }
    }
}
