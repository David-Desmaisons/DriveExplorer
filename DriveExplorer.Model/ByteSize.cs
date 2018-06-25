namespace DriverExplorer.Model
 {
    public struct ByteSize
    {
        private const long _Factor = 1024;

        public long SizeInByte { get; }
        public double SizeInKiloByte => ((double) SizeInByte) / _Factor;
        public double SizeInMegaByte => SizeInKiloByte / _Factor;
        public double SizeInGigaByte => SizeInMegaByte / _Factor;
        public double SizeInTerabytes => SizeInGigaByte / _Factor;

        public ByteSize(long sizeInByte)
        {
            SizeInByte = sizeInByte;
        }

        public override string ToString()
        {
            var sizeInGB = SizeInGigaByte;
            if (sizeInGB >= 1000)
                return $"{SizeInTerabytes:0.00} TB";

            var sizeInMB = SizeInMegaByte;
            if (sizeInMB >= 1000)
                return $"{sizeInGB:0.00} GB";

            var sizeInKilo = SizeInKiloByte;
            if (sizeInKilo >= 1000)
                return $"{sizeInMB:0.00} MB";

            return (SizeInByte >= 1000) ? $"{sizeInKilo:0.00} KB" : $"{SizeInByte} Bytes";
        }

        public static ByteSize FromKB(long sizeInKB) => new ByteSize(_Factor * sizeInKB);
        public static ByteSize FromMB(long sizeInMB) => FromKB(_Factor * sizeInMB);
        public static ByteSize FromGB(long sizeInGB) => FromMB(_Factor * sizeInGB);
        public static ByteSize FromTB(long sizeInTB) => FromGB(_Factor * sizeInTB);
    }
}
