namespace MAUIverter.Model
{
    public sealed record TemperatureUnit(
        string Name,
        string Symbol,
        Func<double, double> ToCelsius,
        Func<double, double> FromCelsius)
    {
        public override string ToString() => $"{Name} ({Symbol})";
    }

    public static class TemperatureConverter
    {
        public static TemperatureUnit Celsius { get; } = new(
            "Celsius",
            "°C",
            celsius => celsius,
            celsius => celsius);

        public static TemperatureUnit Fahrenheit { get; } = new(
            "Fahrenheit",
            "°F",
            fahrenheit => (fahrenheit - 32d) * 5d / 9d,
            celsius => celsius * 9d / 5d + 32d);

        public static TemperatureUnit Kelvin { get; } = new(
            "Kelvin",
            "K",
            kelvin => kelvin - 273.15d,
            celsius => celsius + 273.15d);

        public static TemperatureUnit Rankine { get; } = new(
            "Rankine",
            "°R",
            rankine => rankine * 5d / 9d - 273.15d,
            celsius => (celsius + 273.15d) * 9d / 5d);

        public static List<TemperatureUnit> Units { get; } = new()
        {
            Celsius,
            Fahrenheit,
            Kelvin,
            Rankine,
        };

        public static List<string> UnitNames { get; } = Units.ConvertAll(unit => unit.ToString());

        public static int IndexOf(TemperatureUnit unit) => Units.IndexOf(unit);

        public static double Convert(double value, TemperatureUnit from, TemperatureUnit to)
            => to.FromCelsius(from.ToCelsius(value));
    }
}
