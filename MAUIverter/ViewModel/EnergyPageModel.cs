using MAUIverter.Model;

namespace MAUIverter.ViewModel
{
    public sealed class EnergyPageModel : ConverterPageModel<EnergyUnit>
    {
        public override IReadOnlyList<EnergyUnit> Units => EnergyConverter.Units;

        public override IReadOnlyList<string> UnitNames => EnergyConverter.UnitNames;

        protected override EnergyUnit DefaultFrom => EnergyConverter.Kilojoule;

        protected override EnergyUnit DefaultTo => EnergyConverter.Kilocalorie;

        protected override string DefaultValue => "1";

        protected override bool ShowSizeComparison => true;

        protected override int IndexOf(EnergyUnit unit) => EnergyConverter.IndexOf(unit);

        protected override double ConvertValue(double value, EnergyUnit from, EnergyUnit to)
            => EnergyConverter.Convert(value, from, to);

        protected override string UnitName(EnergyUnit unit) => unit.Name;

        protected override string UnitSymbol(EnergyUnit unit) => unit.Symbol;

        protected override double Factor(EnergyUnit unit) => unit.Joules;
    }
}
