using System.Globalization;

namespace MAUIverter
{
    public partial class InformationPage : ContentPage
    {
        public InformationPage()
        {
            InitializeComponent();

            FromPicker.ItemsSource = InformationConverter.UnitNames;
            ToPicker.ItemsSource = InformationConverter.UnitNames;
            FromPicker.SelectedIndex = InformationConverter.IndexOf(InformationConverter.Megabyte);
            ToPicker.SelectedIndex = InformationConverter.IndexOf(InformationConverter.Mebibyte);

            ValueEntry.Text = "1";
        }

        private async void OnBackClicked(object? sender, EventArgs e)
            => await Navigation.PopAsync();

        private void OnValueTextChanged(object? sender, TextChangedEventArgs e)
        {
        }

        private void OnUnitChanged(object? sender, EventArgs e)
        {
        }

        private async void OnConvertClicked(object? sender, EventArgs e)
        {
            UpdateResult();
            await PopResultAsync();
        }

        private void OnSwapClicked(object? sender, EventArgs e)
        {
            if (FromPicker.SelectedIndex < 0 || ToPicker.SelectedIndex < 0)
                return;

            int fromIndex = FromPicker.SelectedIndex;
            FromPicker.SelectedIndex = ToPicker.SelectedIndex;
            ToPicker.SelectedIndex = fromIndex;
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

            InformationUnit from = InformationConverter.Units[FromPicker.SelectedIndex];
            InformationUnit to = InformationConverter.Units[ToPicker.SelectedIndex];

            if (!double.TryParse(ValueEntry.Text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double value))
            {
                ResultLabel.Text = "--";
                EquationLabel.Text = "Type a number to convert!";
                return;
            }

            double result = InformationConverter.Convert(value, from, to);

            ResultLabel.Text = Format(result);
            EquationLabel.Text = $"{Format(value)} {from.Name} = {Format(result)} {to.Name}";

            UpdateSizeCheck(from, to);
        }

        private void UpdateSizeCheck(InformationUnit from, InformationUnit to)
        {
            double largest = Math.Max(from.Bits, to.Bits);

            FromSizeLabel.Text = $"{from.Name} ({from.Symbol})";
            ToSizeLabel.Text = $"{to.Name} ({to.Symbol})";
            FromSizeBar.Progress = largest > 0 ? from.Bits / largest : 0;
            ToSizeBar.Progress = largest > 0 ? to.Bits / largest : 0;
        }

        private static string Format(double value)
            => value.ToString("G6", CultureInfo.CurrentCulture);
    }
}
