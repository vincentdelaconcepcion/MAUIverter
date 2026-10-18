using MAUIverter.Model;

namespace MAUIverter.ViewModel
{
    public sealed class SpeedPageModel : ConverterPageModel<SpeedUnit>
    {
        public override IReadOnlyList<SpeedUnit> Units => SpeedConverter.Units;

        public override IReadOnlyList<string> UnitNames => SpeedConverter.UnitNames;

        protected override SpeedUnit DefaultFrom => SpeedConverter.KilometerPerHour;

        protected override SpeedUnit DefaultTo => SpeedConverter.MilePerHour;

        protected override string DefaultValue => "1";

        protected override bool ShowSizeComparison => true;

        protected override int IndexOf(SpeedUnit unit) => SpeedConverter.IndexOf(unit);

        protected override double ConvertValue(double value, SpeedUnit from, SpeedUnit to)
            => SpeedConverter.Convert(value, from, to);

        protected override string UnitName(SpeedUnit unit) => unit.Name;

        protected override string UnitSymbol(SpeedUnit unit) => unit.Symbol;

        protected override double Factor(SpeedUnit unit) => unit.MetersPerSecond;
    }
}
