using MAUIverter.Model;

namespace MAUIverter.ViewModel
{
    public sealed class LengthPageModel : ConverterPageModel<LengthUnit>
    {
        public override IReadOnlyList<LengthUnit> Units => LengthConverter.Units;

        public override IReadOnlyList<string> UnitNames => LengthConverter.UnitNames;

        protected override LengthUnit DefaultFrom => LengthConverter.Meter;

        protected override LengthUnit DefaultTo => LengthConverter.Foot;

        protected override string DefaultValue => "1";

        protected override bool ShowSizeComparison => true;

        protected override int IndexOf(LengthUnit unit) => LengthConverter.IndexOf(unit);

        protected override double ConvertValue(double value, LengthUnit from, LengthUnit to)
            => LengthConverter.Convert(value, from, to);

        protected override string UnitName(LengthUnit unit) => unit.Name;

        protected override string UnitSymbol(LengthUnit unit) => unit.Symbol;

        protected override double Factor(LengthUnit unit) => unit.Meters;
    }
}
