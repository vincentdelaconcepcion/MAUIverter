using System.Globalization;

namespace MAUIverter
{
    public partial class TemperaturePage : ContentPage
    {
        public TemperaturePage()
        {
            InitializeComponent();

            FromPicker.ItemsSource = TemperatureConverter.UnitNames;
            ToPicker.ItemsSource = TemperatureConverter.UnitNames;
            FromPicker.SelectedIndex = TemperatureConverter.IndexOf(TemperatureConverter.Celsius);
            ToPicker.SelectedIndex = TemperatureConverter.IndexOf(TemperatureConverter.Fahrenheit);

            ValueEntry.Text = "0";
        }

        private async void OnBackClicked(object? sender, EventArgs e)
            => await Navigation.PopAsync();

        private void OnValueTextChanged(object? sender, TextChangedEventArgs e)
            => UpdateResult();

        private void OnUnitChanged(object? sender, EventArgs e)
            => UpdateResult();

        private async void OnConvertClicked(object? sender, EventArgs e)
        {
            UpdateResult();
            await PopResultAsync();
        }

        private async void OnSwapClicked(object? sender, EventArgs e)
        {
            if (FromPicker.SelectedIndex < 0 || ToPicker.SelectedIndex < 0)
                return;

            int fromIndex = FromPicker.SelectedIndex;
            FromPicker.SelectedIndex = ToPicker.SelectedIndex;
            ToPicker.SelectedIndex = fromIndex;

            UpdateResult();
            await PopResultAsync();
        }

        private async Task PopResultAsync()
        {
            await ResultCard.FadeToAsync(0, 90);
            await ResultCard.ScaleToAsync(0.94, 90);
            await Task.WhenAll(ResultCard.FadeToAsync(1, 130), ResultCard.ScaleToAsync(1, 130));
        }

        private void UpdateResult()
        {
            if (FromPicker.SelectedIndex < 0 || ToPicker.SelectedIndex < 0)
                return;

            TemperatureUnit from = TemperatureConverter.Units[FromPicker.SelectedIndex];
            TemperatureUnit to = TemperatureConverter.Units[ToPicker.SelectedIndex];

            if (!double.TryParse(ValueEntry.Text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double value))
            {
                ResultLabel.Text = "--";
                EquationLabel.Text = "Type a number to convert!";
                return;
            }

            double result = TemperatureConverter.Convert(value, from, to);

            ResultLabel.Text = Format(result);
            EquationLabel.Text = $"{Format(value)} {from.Name} = {Format(result)} {to.Name}";

        }

        private static string Format(double value)
            => value.ToString("G6", CultureInfo.CurrentCulture);
    }
}
