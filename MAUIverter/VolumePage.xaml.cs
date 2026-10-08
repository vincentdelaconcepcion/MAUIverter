using System.Globalization;

namespace MAUIverter
{
    public partial class VolumePage : ContentPage
    {
        public VolumePage()
        {
            InitializeComponent();

            FromPicker.ItemsSource = VolumeConverter.UnitNames;
            ToPicker.ItemsSource = VolumeConverter.UnitNames;
            FromPicker.SelectedIndex = VolumeConverter.IndexOf(VolumeConverter.Liter);
            ToPicker.SelectedIndex = VolumeConverter.IndexOf(VolumeConverter.UsGallon);

            ValueEntry.Text = "1";
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

            VolumeUnit from = VolumeConverter.Units[FromPicker.SelectedIndex];
            VolumeUnit to = VolumeConverter.Units[ToPicker.SelectedIndex];

            if (!double.TryParse(ValueEntry.Text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double value))
            {
                ResultLabel.Text = "--";
                EquationLabel.Text = "Type a number to convert!";
                return;
            }

            double result = VolumeConverter.Convert(value, from, to);

            ResultLabel.Text = Format(result);
            EquationLabel.Text = $"{Format(value)} {from.Name} = {Format(result)} {to.Name}";

            UpdateSizeCheck(from, to);
        }

        private void UpdateSizeCheck(VolumeUnit from, VolumeUnit to)
        {
            double largest = Math.Max(from.Liters, to.Liters);

            FromSizeLabel.Text = $"{from.Name} ({from.Symbol})";
            ToSizeLabel.Text = $"{to.Name} ({to.Symbol})";
            FromSizeBar.Progress = largest > 0 ? from.Liters / largest : 0;
            ToSizeBar.Progress = largest > 0 ? to.Liters / largest : 0;
        }

        private static string Format(double value)
            => value.ToString("G6", CultureInfo.CurrentCulture);
    }
}
