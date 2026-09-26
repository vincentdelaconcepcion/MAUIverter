using System.Globalization;

namespace MAUIverter
{
    public partial class DurationPage : ContentPage
    {
        public DurationPage()
        {
            InitializeComponent();

            FromPicker.ItemsSource = DurationConverter.UnitNames;
            ToPicker.ItemsSource = DurationConverter.UnitNames;
            FromPicker.SelectedIndex = DurationConverter.IndexOf(DurationConverter.Minute);
            ToPicker.SelectedIndex = DurationConverter.IndexOf(DurationConverter.Second);

            ValueEntry.Text = "1";
        }

        private void OnConvertClicked(object? sender, EventArgs e)
            => UpdateResult();

        private void OnValueTextChanged(object? sender, TextChangedEventArgs e)
            => UpdateResult();

        private void OnUnitChanged(object? sender, EventArgs e)
            => UpdateResult();

        private void OnSwapClicked(object? sender, EventArgs e)
        {
            if (FromPicker.SelectedIndex < 0 || ToPicker.SelectedIndex < 0)
                return;

            int fromIndex = FromPicker.SelectedIndex;
            FromPicker.SelectedIndex = ToPicker.SelectedIndex;
            ToPicker.SelectedIndex = fromIndex;

            UpdateResult();
        }

        private void UpdateResult()
        {
            if (FromPicker.SelectedIndex < 0 || ToPicker.SelectedIndex < 0)
                return;

            DurationUnit from = DurationConverter.Units[FromPicker.SelectedIndex];
            DurationUnit to = DurationConverter.Units[ToPicker.SelectedIndex];

            if (!double.TryParse(ValueEntry.Text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double value))
            {
                ResultLabel.Text = "--";
                EquationLabel.Text = "Enter a number to convert";
                return;
            }

            double result = DurationConverter.Convert(value, from, to);

            ResultLabel.Text = Format(result);
            EquationLabel.Text = $"{Format(value)} {from.Name} = {Format(result)} {to.Name}";
        }

        private static string Format(double value)
            => value.ToString("G12", CultureInfo.CurrentCulture);
    }
}
