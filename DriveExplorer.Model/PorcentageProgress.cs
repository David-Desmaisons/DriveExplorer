namespace DriveExplorer.Model
{
    public class PorcentageProgress
    {
        public int? Total { get; }
        public int Current { get; }

        public PorcentageProgress(int? total, int current)
        {
            Total = total;
            Current = current;
        }

        public override string ToString()
        {
            return $"{Current}{(Total.HasValue? $"/ {Total}": string.Empty)}";
        }
    }
}
