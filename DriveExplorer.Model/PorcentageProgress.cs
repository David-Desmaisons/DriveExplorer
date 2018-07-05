namespace DriveExplorer.Model
{
    public class PorcentageProgress
    {
        public int Total { get; }
        public int Current { get; set; }

        public PorcentageProgress(int total)
        {
            Total = total;
            Current = 0;
        }

        public override string ToString()
        {
            return $"{Current} / {Total}";
        }
    }
}
