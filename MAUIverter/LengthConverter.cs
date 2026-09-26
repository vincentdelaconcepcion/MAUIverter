namespace MAUIverter
{
    public sealed record LengthUnit(string Name, string Symbol, double Meters)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class LengthConverter
    {
        public static LengthUnit Meter { get; } = new("Meter", "m", 1d);
        public static LengthUnit Foot { get; } = new("Foot", "ft", 0.3048d);

        public static List<LengthUnit> Units { get; } = new()
        {
            new("Nanometer", "nm", 0.000000001d),
            new("Micrometer", "µm", 0.000001d),
            new("Millimeter", "mm", 0.001d),
            new("Centimeter", "cm", 0.01d),
            new("Decimeter", "dm", 0.1d),
            Meter,
            new("Decameter", "dam", 10d),
            new("Hectometer", "hm", 100d),
            new("Kilometer", "km", 1000d),
            new("Inch", "in", 0.0254d),
            Foot,
            new("Yard", "yd", 0.9144d),
            new("Mile", "mi", 1609.344d),
            new("Nautical Mile", "nmi", 1852d),
            new("Furlong", "fur", 201.168d),
            new("Chain", "ch", 20.1168d),
            new("Rod", "rd", 5.0292d),
            new("Fathom", "ftm", 1.8288d),
            new("Astronomical Unit", "AU", 149597870700d),
            new("Light Year", "ly", 9.4607304725808E15d),
            new("Parsec", "pc", 3.085677581491367E16d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(LengthUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, LengthUnit from, LengthUnit to)
            => value * from.Meters / to.Meters;
    }
}
