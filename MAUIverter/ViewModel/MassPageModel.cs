using MAUIverter.Model;

namespace MAUIverter.ViewModel
{
    public sealed class MassPageModel : ConverterPageModel<MassUnit>
    {
        public override IReadOnlyList<MassUnit> Units => MassConverter.Units;

        public override IReadOnlyList<string> UnitNames => MassConverter.UnitNames;

        protected override MassUnit DefaultFrom => MassConverter.Kilogram;

        protected override MassUnit DefaultTo => MassConverter.Pound;

        protected override string DefaultValue => "1";

        protected override bool ShowSizeComparison => true;

        protected override int IndexOf(MassUnit unit) => MassConverter.IndexOf(unit);

        protected override double ConvertValue(double value, MassUnit from, MassUnit to)
            => MassConverter.Convert(value, from, to);

        protected override string UnitName(MassUnit unit) => unit.Name;

        protected override string UnitSymbol(MassUnit unit) => unit.Symbol;

        protected override double Factor(MassUnit unit) => unit.Kilograms;
    }
}
