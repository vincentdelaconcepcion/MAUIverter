using MAUIverter.Model;

namespace MAUIverter.ViewModel
{
    public sealed class VolumePageModel : ConverterPageModel<VolumeUnit>
    {
        public override IReadOnlyList<VolumeUnit> Units => VolumeConverter.Units;

        public override IReadOnlyList<string> UnitNames => VolumeConverter.UnitNames;

        protected override VolumeUnit DefaultFrom => VolumeConverter.Liter;

        protected override VolumeUnit DefaultTo => VolumeConverter.UsGallon;

        protected override string DefaultValue => "1";

        protected override bool ShowSizeComparison => true;

        protected override int IndexOf(VolumeUnit unit) => VolumeConverter.IndexOf(unit);

        protected override double ConvertValue(double value, VolumeUnit from, VolumeUnit to)
            => VolumeConverter.Convert(value, from, to);

        protected override string UnitName(VolumeUnit unit) => unit.Name;

        protected override string UnitSymbol(VolumeUnit unit) => unit.Symbol;

        protected override double Factor(VolumeUnit unit) => unit.Liters;
    }
}
