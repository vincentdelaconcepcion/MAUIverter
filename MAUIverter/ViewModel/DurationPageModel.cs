using MAUIverter.Model;

namespace MAUIverter.ViewModel
{
    public sealed class DurationPageModel : ConverterPageModel<DurationUnit>
    {
        public override IReadOnlyList<DurationUnit> Units => DurationConverter.Units;

        public override IReadOnlyList<string> UnitNames => DurationConverter.UnitNames;

        protected override DurationUnit DefaultFrom => DurationConverter.Minute;

        protected override DurationUnit DefaultTo => DurationConverter.Second;

        protected override string DefaultValue => "1";

        protected override bool ShowSizeComparison => true;

        protected override int IndexOf(DurationUnit unit) => DurationConverter.IndexOf(unit);

        protected override double ConvertValue(double value, DurationUnit from, DurationUnit to)
            => DurationConverter.Convert(value, from, to);

        protected override string UnitName(DurationUnit unit) => unit.Name;

        protected override string UnitSymbol(DurationUnit unit) => unit.Symbol;

        protected override double Factor(DurationUnit unit) => unit.Seconds;
    }
}
