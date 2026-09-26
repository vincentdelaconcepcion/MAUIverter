using System.Globalization;

namespace MAUIverter
{
    public partial class SpeedPage : ContentPage
    {
        public SpeedPage()
        {
            InitializeComponent();

            FromPicker.ItemsSource = SpeedConverter.UnitNames;
            ToPicker.ItemsSource = SpeedConverter.UnitNames;
            FromPicker.SelectedIndex = SpeedConverter.IndexOf(SpeedConverter.KilometerPerHour);
            ToPicker.SelectedIndex = SpeedConverter.IndexOf(SpeedConverter.MilePerHour);

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

            SpeedUnit from = SpeedConverter.Units[FromPicker.SelectedIndex];
            SpeedUnit to = SpeedConverter.Units[ToPicker.SelectedIndex];

            if (!double.TryParse(ValueEntry.Text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double value))
            {
                ResultLabel.Text = "--";
                EquationLabel.Text = "Enter a number to convert";
                return;
            }

            double result = SpeedConverter.Convert(value, from, to);

            ResultLabel.Text = Format(result);
            EquationLabel.Text = $"{Format(value)} {from.Name} = {Format(result)} {to.Name}";
        }

        private static string Format(double value)
            => value.ToString("G12", CultureInfo.CurrentCulture);
    }
}
