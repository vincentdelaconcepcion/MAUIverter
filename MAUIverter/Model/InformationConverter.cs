namespace MAUIverter.Model
{
    public sealed record InformationUnit(string Name, string Symbol, double Bits)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class InformationConverter
    {
        public static InformationUnit Megabyte { get; } = new("Megabyte", "MB", 8_000_000d);
        public static InformationUnit Mebibyte { get; } = new("Mebibyte", "MiB", 8_388_608d);

        public static List<InformationUnit> Units { get; } = new()
        {
            new("Bit", "b", 1d),
            new("Byte", "B", 8d),
            new("Kilobit", "kbit", 1_000d),
            new("Kibibit", "Kibit", 1_024d),
            new("Megabit", "Mbit", 1_000_000d),
            new("Mebibit", "Mibit", 1_048_576d),
            new("Gigabit", "Gbit", 1_000_000_000d),
            new("Gibibit", "Gibit", 1_073_741_824d),
            new("Terabit", "Tbit", 1_000_000_000_000d),
            new("Tebibit", "Tibit", 1_099_511_627_776d),
            new("Petabit", "Pbit", 1_000_000_000_000_000d),
            new("Pebibit", "Pibit", 1_125_899_906_842_624d),
            new("Kilobyte", "kB", 8_000d),
            new("Kibibyte", "KiB", 8_192d),
            Megabyte,
            Mebibyte,
            new("Gigabyte", "GB", 8_000_000_000d),
            new("Gibibyte", "GiB", 8_589_934_592d),
            new("Terabyte", "TB", 8_000_000_000_000d),
            new("Tebibyte", "TiB", 8_796_093_022_208d),
            new("Petabyte", "PB", 8_000_000_000_000_000d),
            new("Pebibyte", "PiB", 9_007_199_254_740_992d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(InformationUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, InformationUnit from, InformationUnit to)
            => value * from.Bits / to.Bits;
    }
}
