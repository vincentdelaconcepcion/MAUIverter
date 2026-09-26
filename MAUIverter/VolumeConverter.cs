namespace MAUIverter
{
    public sealed record VolumeUnit(string Name, string Symbol, double Liters)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class VolumeConverter
    {
        public static VolumeUnit Liter { get; } = new("Liter", "L", 1d);
        public static VolumeUnit UsGallon { get; } = new("US Gallon", "gal", 3.785411784d);

        public static List<VolumeUnit> Units { get; } = new()
        {
            new("Cubic Millimeter", "mm\u00b3", 0.000001d),
            new("Microliter", "\u00b5L", 0.000001d),
            new("Milliliter", "mL", 0.001d),
            new("Cubic Centimeter", "cm\u00b3", 0.001d),
            new("Centiliter", "cL", 0.01d),
            new("Deciliter", "dL", 0.1d),
            Liter,
            new("Hectoliter", "hL", 100d),
            new("Cubic Meter", "m\u00b3", 1000d),
            new("US Teaspoon", "tsp", 0.00492892159375d),
            new("US Tablespoon", "tbsp", 0.01478676478125d),
            new("US Fluid Ounce", "fl oz", 0.0295735295625d),
            new("US Cup", "cup", 0.2365882365d),
            new("US Gill", "gill", 0.11829411825d),
            new("US Pint", "pt", 0.473176473d),
            new("US Quart", "qt", 0.946352946d),
            UsGallon,
            new("Oil Barrel", "bbl", 158.987294928d),
            new("US Dry Cup", "dry cup", 0.275305207366d),
            new("US Dry Pint", "dry pt", 0.550610414732d),
            new("US Dry Quart", "dry qt", 1.101220829465d),
            new("US Dry Gallon", "dry gal", 4.40488331786d),
            new("Peck", "pk", 8.80976663572d),
            new("Bushel", "bu", 35.23906654288d),
            new("Imperial Teaspoon", "imp tsp", 0.005919388020833d),
            new("Imperial Tablespoon", "imp tbsp", 0.0177581640625d),
            new("Imperial Fluid Ounce", "imp fl oz", 0.0284130625d),
            new("Imperial Gill", "imp gill", 0.1420653125d),
            new("Imperial Pint", "imp pt", 0.56826125d),
            new("Imperial Quart", "imp qt", 1.1365225d),
            new("Imperial Gallon", "imp gal", 4.54609d),
            new("Cubic Inch", "in\u00b3", 0.016387064d),
            new("Cubic Foot", "ft\u00b3", 28.316846592d),
            new("Cubic Yard", "yd\u00b3", 764.554857984d),
            new("Board Foot", "fbm", 2.359737216d),
            new("Cord", "cord", 3624.556363776d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(VolumeUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, VolumeUnit from, VolumeUnit to)
            => value * from.Liters / to.Liters;
    }
}
