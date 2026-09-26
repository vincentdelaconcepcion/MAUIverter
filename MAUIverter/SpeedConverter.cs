namespace MAUIverter
{
    public sealed record SpeedUnit(string Name, string Symbol, double MetersPerSecond)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class SpeedConverter
    {
        public static SpeedUnit KilometerPerHour { get; } = new("Kilometer per Hour", "km/h", 0.2777777777777778d);
        public static SpeedUnit MilePerHour { get; } = new("Mile per Hour", "mph", 0.44704d);

        public static List<SpeedUnit> Units { get; } = new()
        {
            new("Meter per Second", "m/s", 1d),
            KilometerPerHour,
            MilePerHour,
            new("Foot per Second", "ft/s", 0.3048d),
            new("Knot", "kn", 0.5144444444444444d),
            new("Foot per Minute", "ft/min", 0.00508d),
            new("Inch per Second", "in/s", 0.0254d),
            new("Meter per Minute", "m/min", 0.0166666666666667d),
            new("Kilometer per Second", "km/s", 1000d),
            new("Speed of Light", "c", 299792458d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(SpeedUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, SpeedUnit from, SpeedUnit to)
            => value * from.MetersPerSecond / to.MetersPerSecond;
    }
}
