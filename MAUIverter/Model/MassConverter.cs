namespace MAUIverter.Model
{
    public sealed record MassUnit(string Name, string Symbol, double Kilograms)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class MassConverter
    {
        public static MassUnit Kilogram { get; } = new("Kilogram", "kg", 1d);
        public static MassUnit Pound { get; } = new("Pound", "lb", 0.45359237d);

        public static List<MassUnit> Units { get; } = new()
        {
            new("Microgram", "\u00B5g", 0.000000001d),
            new("Milligram", "mg", 0.000001d),
            new("Carat", "ct", 0.0002d),
            new("Gram", "g", 0.001d),
            new("Metric Pound", "lb-m", 0.5d),
            Kilogram,
            new("Tonne", "t", 1000d),
            new("Grain", "gr", 0.00006479891d),
            new("Pennyweight", "dwt", 0.00155517384d),
            new("Troy Ounce", "oz t", 0.0311034768d),
            new("Troy Pound", "lb t", 0.3732417216d),
            new("Dram", "dr", 0.0017718451953125d),
            new("Ounce", "oz", 0.028349523125d),
            Pound,
            new("Stone", "st", 6.35029318d),
            new("Hundredweight (US)", "cwt", 45.359237d),
            new("Hundredweight (Imperial)", "cwt-imp", 50.80234544d),
            new("Short Ton", "ton", 907.18474d),
            new("Long Ton", "long ton", 1016.0469088d),
            new("Slug", "slug", 14.593902937206362d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(MassUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, MassUnit from, MassUnit to)
            => value * from.Kilograms / to.Kilograms;
    }
}
