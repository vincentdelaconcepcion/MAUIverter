namespace MAUIverter.Model
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
            new("Picometer", "pm", 1E-12d),
            new("Angstrom", "\u00C5", 1E-10d),
            new("Nanometer", "nm", 0.000000001d),
            new("Micrometer", "\u00B5m", 0.000001d),
            new("Millimeter", "mm", 0.001d),
            new("Centimeter", "cm", 0.01d),
            new("Decimeter", "dm", 0.1d),
            Meter,
            new("Decameter", "dam", 10d),
            new("Hectometer", "hm", 100d),
            new("Kilometer", "km", 1000d),
            new("Thou", "th", 0.0000254d),
            new("Inch", "in", 0.0254d),
            new("Hand", "hd", 0.1016d),
            Foot,
            new("Yard", "yd", 0.9144d),
            new("Rod", "rd", 5.0292d),
            new("Chain", "ch", 20.1168d),
            new("Furlong", "fur", 201.168d),
            new("Mile", "mi", 1609.344d),
            new("League (statute)", "lea", 4828.032d),
            new("Fathom", "ftm", 1.8288d),
            new("Nautical Mile", "nmi", 1852d),
            new("Nautical League", "nlea", 5556d),
            new("Astronomical Unit", "AU", 149597870700d),
            new("Light Year", "ly", 9.4607304725808E15d),
            new("Parsec", "pc", 3.0856775814913673E16d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(LengthUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, LengthUnit from, LengthUnit to)
            => value * from.Meters / to.Meters;
    }
}
