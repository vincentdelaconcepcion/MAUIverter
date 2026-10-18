namespace MAUIverter.Model
{
    public sealed record SpeedUnit(string Name, string Symbol, double MetersPerSecond)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class SpeedConverter
    {
        public static SpeedUnit KilometerPerHour { get; } = new("Kilometer per Hour", "km/h", 0.27777777777777779d);
        public static SpeedUnit MilePerHour { get; } = new("Mile per Hour", "mph", 0.44704d);

        public static List<SpeedUnit> Units { get; } = new()
        {
            new("Millimeter per Second", "mm/s", 0.001d),
            new("Foot per Minute", "ft/min", 0.00508d),
            new("Centimeter per Second", "cm/s", 0.01d),
            new("Meter per Minute", "m/min", 0.016666666666666666d),
            new("Inch per Second", "in/s", 0.0254d),
            KilometerPerHour,
            new("Foot per Second", "ft/s", 0.3048d),
            MilePerHour,
            new("Knot", "kn", 0.51444444444444448d),
            new("Meter per Second", "m/s", 1d),
            new("Kilometer per Minute", "km/min", 16.666666666666666d),
            new("Mile per Minute", "mi/min", 26.8224d),
            new("Mach (sea level)", "Ma", 340.29d),
            new("Kilometer per Second", "km/s", 1000d),
            new("Speed of Light", "c", 299792458d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(SpeedUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, SpeedUnit from, SpeedUnit to)
            => value * from.MetersPerSecond / to.MetersPerSecond;
    }
}
