using System.Globalization;
using System.Windows.Input;

namespace MAUIverter.ViewModel
{
    public abstract class ConverterPageModel<TUnit> : ObservableObject
    {
        private string _value = "1";
        private int _fromIndex = -1;
        private int _toIndex = -1;
        private string _resultText = string.Empty;
        private string _equationText = string.Empty;
        private string _fromSizeLabel = string.Empty;
        private string _toSizeLabel = string.Empty;
        private double _fromSizeProgress;
        private double _toSizeProgress;

        protected ConverterPageModel()
        {
            ConvertCommand = new RelayCommand(Convert);
            SwapCommand = new RelayCommand(Swap);

            FromIndex = IndexOf(DefaultFrom);
            ToIndex = IndexOf(DefaultTo);
            _value = DefaultValue;
        }

        public abstract IReadOnlyList<TUnit> Units { get; }

        public abstract IReadOnlyList<string> UnitNames { get; }

        protected abstract TUnit DefaultFrom { get; }

        protected abstract TUnit DefaultTo { get; }

        protected abstract string DefaultValue { get; }

        protected abstract bool ShowSizeComparison { get; }

        protected abstract int IndexOf(TUnit unit);

        protected abstract double ConvertValue(double value, TUnit from, TUnit to);

        protected abstract string UnitName(TUnit unit);

        protected abstract string UnitSymbol(TUnit unit);

        protected abstract double Factor(TUnit unit);

        public event EventHandler? ResultUpdated;

        public string Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public int FromIndex
        {
            get => _fromIndex;
            set => SetProperty(ref _fromIndex, value);
        }

        public int ToIndex
        {
            get => _toIndex;
            set => SetProperty(ref _toIndex, value);
        }

        public string ResultText
        {
            get => _resultText;
            private set => SetProperty(ref _resultText, value);
        }

        public string EquationText
        {
            get => _equationText;
            private set => SetProperty(ref _equationText, value);
        }

        public string FromSizeLabel
        {
            get => _fromSizeLabel;
            private set => SetProperty(ref _fromSizeLabel, value);
        }

        public string ToSizeLabel
        {
            get => _toSizeLabel;
            private set => SetProperty(ref _toSizeLabel, value);
        }

        public double FromSizeProgress
        {
            get => _fromSizeProgress;
            private set => SetProperty(ref _fromSizeProgress, value);
        }

        public double ToSizeProgress
        {
            get => _toSizeProgress;
            private set => SetProperty(ref _toSizeProgress, value);
        }

        public ICommand ConvertCommand { get; }

        public ICommand SwapCommand { get; }

        private void Convert()
        {
            UpdateResult();
            ResultUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void Swap()
        {
            if (FromIndex < 0 || FromIndex >= Units.Count || ToIndex < 0 || ToIndex >= Units.Count)
                return;

            (FromIndex, ToIndex) = (ToIndex, FromIndex);
        }

        private void UpdateResult()
        {
            if (FromIndex < 0 || FromIndex >= Units.Count || ToIndex < 0 || ToIndex >= Units.Count)
                return;

            TUnit from = Units[FromIndex];
            TUnit to = Units[ToIndex];

            if (!double.TryParse(Value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double value))
            {
                ResultText = "--";
                EquationText = "Type a number to convert!";
                return;
            }

            double result = ConvertValue(value, from, to);

            ResultText = Format(result);
            EquationText = $"{Format(value)} {UnitName(from)} = {Format(result)} {UnitName(to)}";

            if (!ShowSizeComparison)
                return;

            double fromFactor = Factor(from);
            double toFactor = Factor(to);
            double largest = Math.Max(fromFactor, toFactor);

            FromSizeLabel = $"{UnitName(from)} ({UnitSymbol(from)})";
            ToSizeLabel = $"{UnitName(to)} ({UnitSymbol(to)})";
            FromSizeProgress = largest > 0 ? fromFactor / largest : 0;
            ToSizeProgress = largest > 0 ? toFactor / largest : 0;
        }

        private static string Format(double value)
            => value.ToString("G15", CultureInfo.CurrentCulture);
    }
}
