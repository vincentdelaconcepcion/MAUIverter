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
            new("Microgram", "µg", 0.000000001d),
            new("Milligram", "mg", 0.000001d),
            new("Gram", "g", 0.001d),
            new("Carat", "ct", 0.0002d),
            Kilogram,
            new("Tonne", "t", 1000d),
            new("Grain", "gr", 0.00006479891d),
            new("Dram", "dr", 0.0017718451953125d),
            new("Troy Ounce", "oz t", 0.0311034768d),
            new("Ounce", "oz", 0.028349523125d),
            Pound,
            new("Stone", "st", 6.35029318d),
            new("Hundredweight", "cwt", 45.359237d),
            new("Short Ton", "ton", 907.18474d),
            new("Long Ton", "long ton", 1016.0469088d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(MassUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, MassUnit from, MassUnit to)
            => value * from.Kilograms / to.Kilograms;
    }
}
