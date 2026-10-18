using MAUIverter.Model;

namespace MAUIverter.ViewModel
{
    public sealed class InformationPageModel : ConverterPageModel<InformationUnit>
    {
        public override IReadOnlyList<InformationUnit> Units => InformationConverter.Units;

        public override IReadOnlyList<string> UnitNames => InformationConverter.UnitNames;

        protected override InformationUnit DefaultFrom => InformationConverter.Megabyte;

        protected override InformationUnit DefaultTo => InformationConverter.Mebibyte;

        protected override string DefaultValue => "1";

        protected override bool ShowSizeComparison => true;

        protected override int IndexOf(InformationUnit unit) => InformationConverter.IndexOf(unit);

        protected override double ConvertValue(double value, InformationUnit from, InformationUnit to)
            => InformationConverter.Convert(value, from, to);

        protected override string UnitName(InformationUnit unit) => unit.Name;

        protected override string UnitSymbol(InformationUnit unit) => unit.Symbol;

        protected override double Factor(InformationUnit unit) => unit.Bits;
    }
}
