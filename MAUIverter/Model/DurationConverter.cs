namespace MAUIverter.Model
{
    public sealed record DurationUnit(string Name, string Symbol, double Seconds)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class DurationConverter
    {
        public static DurationUnit Minute { get; } = new("Minute", "min", 60d);
        public static DurationUnit Second { get; } = new("Second", "s", 1d);

        public static List<DurationUnit> Units { get; } = new()
        {
            new("Nanosecond", "ns", 0.000000001d),
            new("Microsecond", "µs", 0.000001d),
            new("Millisecond", "ms", 0.001d),
            Second,
            Minute,
            new("Hour", "h", 3600d),
            new("Day", "d", 86400d),
            new("Week", "wk", 604800d),
            new("Month (average)", "mo", 2629800d),
            new("Year (365 days)", "yr", 31536000d),
            new("Year (365.25 days)", "yr", 31557600d),
            new("Decade", "dec", 315576000d),
            new("Century", "cent", 3155760000d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(DurationUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, DurationUnit from, DurationUnit to)
            => value * from.Seconds / to.Seconds;
    }
}
