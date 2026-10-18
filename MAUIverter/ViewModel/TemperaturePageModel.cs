using MAUIverter.Model;

namespace MAUIverter.ViewModel
{
    public sealed class TemperaturePageModel : ConverterPageModel<TemperatureUnit>
    {
        public override IReadOnlyList<TemperatureUnit> Units => TemperatureConverter.Units;

        public override IReadOnlyList<string> UnitNames => TemperatureConverter.UnitNames;

        protected override TemperatureUnit DefaultFrom => TemperatureConverter.Celsius;

        protected override TemperatureUnit DefaultTo => TemperatureConverter.Fahrenheit;

        protected override string DefaultValue => "0";

        protected override bool ShowSizeComparison => false;

        protected override int IndexOf(TemperatureUnit unit) => TemperatureConverter.IndexOf(unit);

        protected override double ConvertValue(double value, TemperatureUnit from, TemperatureUnit to)
            => TemperatureConverter.Convert(value, from, to);

        protected override string UnitName(TemperatureUnit unit) => unit.Name;

        protected override string UnitSymbol(TemperatureUnit unit) => unit.Symbol;

        protected override double Factor(TemperatureUnit unit) => 0d;
    }
}
