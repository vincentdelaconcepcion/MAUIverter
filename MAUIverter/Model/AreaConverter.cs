namespace MAUIverter.Model
{
    public sealed record AreaUnit(string Name, string Symbol, double SquareMeters)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class AreaConverter
    {
        public static AreaUnit SquareMeter { get; } = new("Square Meter", "m\u00B2", 1d);
        public static AreaUnit SquareFoot { get; } = new("Square Foot", "ft\u00B2", 0.09290304d);

        public static List<AreaUnit> Units { get; } = new()
        {
            new("Square Micrometer", "\u00B5m\u00B2", 1E-12d),
            new("Circular Mil", "cmil", 5.0670747909749781E-10d),
            new("Square Millimeter", "mm\u00B2", 0.000001d),
            new("Square Centimeter", "cm\u00B2", 0.0001d),
            new("Square Decimeter", "dm\u00B2", 0.01d),
            SquareMeter,
            new("Are", "a", 100d),
            new("Dunam", "dunam", 1000d),
            new("Rood", "rood", 1011.7141056d),
            new("Hectare", "ha", 10000d),
            new("Square Kilometer", "km\u00B2", 1000000d),
            new("Square Inch", "in\u00B2", 0.00064516d),
            SquareFoot,
            new("Square Yard", "yd\u00B2", 0.83612736d),
            new("Acre", "ac", 4046.8564224d),
            new("Square Mile", "mi\u00B2", 2589988.110336d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(AreaUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, AreaUnit from, AreaUnit to)
            => value * from.SquareMeters / to.SquareMeters;
    }
}
