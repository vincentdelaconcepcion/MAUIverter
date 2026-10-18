namespace MAUIverter.Model
{
    public sealed record AreaUnit(string Name, string Symbol, double SquareMeters)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class AreaConverter
    {
        public static AreaUnit SquareMeter { get; } = new("Square Meter", "m²", 1d);
        public static AreaUnit SquareFoot { get; } = new("Square Foot", "ft²", 0.09290304d);

        public static List<AreaUnit> Units { get; } = new()
        {
            new("Square Millimeter", "mm²", 0.000001d),
            new("Square Centimeter", "cm²", 0.0001d),
            new("Square Decimeter", "dm²", 0.01d),
            SquareMeter,
            new("Are", "a", 100d),
            new("Hectare", "ha", 10000d),
            new("Square Kilometer", "km²", 1000000d),
            new("Square Inch", "in²", 0.00064516d),
            SquareFoot,
            new("Square Yard", "yd²", 0.83612736d),
            new("Acre", "ac", 4046.8564224d),
            new("Square Mile", "mi²", 2589988.110336d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(AreaUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, AreaUnit from, AreaUnit to)
            => value * from.SquareMeters / to.SquareMeters;
    }
}
