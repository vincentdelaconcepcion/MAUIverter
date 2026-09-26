using System.Globalization;

namespace MAUIverter
{
    public partial class EnergyPage : ContentPage
    {
        public EnergyPage()
        {
            InitializeComponent();

            FromPicker.ItemsSource = EnergyConverter.UnitNames;
            ToPicker.ItemsSource = EnergyConverter.UnitNames;
            FromPicker.SelectedIndex = EnergyConverter.IndexOf(EnergyConverter.Kilojoule);
            ToPicker.SelectedIndex = EnergyConverter.IndexOf(EnergyConverter.Kilocalorie);

            ValueEntry.Text = "1";
        }

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

            EnergyUnit from = EnergyConverter.Units[FromPicker.SelectedIndex];
            EnergyUnit to = EnergyConverter.Units[ToPicker.SelectedIndex];

            if (!double.TryParse(ValueEntry.Text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double value))
            {
                ResultLabel.Text = "--";
                EquationLabel.Text = "Type a number to convert!";
                return;
            }

            double result = EnergyConverter.Convert(value, from, to);

            ResultLabel.Text = Format(result);
            EquationLabel.Text = $"{Format(value)} {from.Name} = {Format(result)} {to.Name}";

            UpdateSizeCheck(from, to);
        }

        private void UpdateSizeCheck(EnergyUnit from, EnergyUnit to)
        {
            double largest = Math.Max(from.Joules, to.Joules);

            FromSizeLabel.Text = $"{from.Name} ({from.Symbol})";
            ToSizeLabel.Text = $"{to.Name} ({to.Symbol})";
            FromSizeBar.Progress = largest > 0 ? from.Joules / largest : 0;
            ToSizeBar.Progress = largest > 0 ? to.Joules / largest : 0;
        }

        private static string Format(double value)
            => value.ToString("G6", CultureInfo.CurrentCulture);
    }
}
