using MAUIverter.Model;

namespace MAUIverter.ViewModel
{
    public sealed class AreaPageModel : ConverterPageModel<AreaUnit>
    {
        public override IReadOnlyList<AreaUnit> Units => AreaConverter.Units;

        public override IReadOnlyList<string> UnitNames => AreaConverter.UnitNames;

        protected override AreaUnit DefaultFrom => AreaConverter.SquareMeter;

        protected override AreaUnit DefaultTo => AreaConverter.SquareFoot;

        protected override string DefaultValue => "1";

        protected override bool ShowSizeComparison => true;

        protected override int IndexOf(AreaUnit unit) => AreaConverter.IndexOf(unit);

        protected override double ConvertValue(double value, AreaUnit from, AreaUnit to)
            => AreaConverter.Convert(value, from, to);

        protected override string UnitName(AreaUnit unit) => unit.Name;

        protected override string UnitSymbol(AreaUnit unit) => unit.Symbol;

        protected override double Factor(AreaUnit unit) => unit.SquareMeters;
    }
}
