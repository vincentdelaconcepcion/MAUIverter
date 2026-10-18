namespace MAUIverter.Model
{
    public sealed record EnergyUnit(string Name, string Symbol, double Joules)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class EnergyConverter
    {
        public static EnergyUnit Kilojoule { get; } = new("Kilojoule", "kJ", 1000d);
        public static EnergyUnit Kilocalorie { get; } = new("Kilocalorie", "kcal", 4184d);

        public static List<EnergyUnit> Units { get; } = new()
        {
            new("Electronvolt", "eV", 1.602176634E-19d),
            new("Erg", "erg", 0.0000001d),
            new("Joule", "J", 1d),
            new("Foot-Pound", "ft\u00B7lb", 1.3558179483314004d),
            new("Calorie", "cal", 4.184d),
            Kilojoule,
            new("British Thermal Unit", "BTU", 1055.05585262d),
            new("Watt Hour", "Wh", 3600d),
            Kilocalorie,
            new("Megajoule", "MJ", 1000000d),
            new("Kilo BTU", "kBtu", 1055055.85262d),
            new("Horsepower Hour", "hp\u00B7h", 2684519.5376961725d),
            new("Kilowatt Hour", "kWh", 3600000d),
            new("Megacalorie", "Mcal", 4184000d),
            new("Therm", "thm", 105505585.262d),
            new("Gigajoule", "GJ", 1000000000d),
            new("Megawatt Hour", "MWh", 3600000000d),
            new("Tonne of Oil Equivalent", "toe", 41868000000d),
            new("Gigawatt Hour", "GWh", 3600000000000d),
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(EnergyUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, EnergyUnit from, EnergyUnit to)
            => value * from.Joules / to.Joules;
    }
}
