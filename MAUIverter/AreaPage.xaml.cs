using System.Globalization;

namespace MAUIverter
{
    public partial class AreaPage : ContentPage
    {
        public AreaPage()
        {
            InitializeComponent();

            FromPicker.ItemsSource = AreaConverter.UnitNames;
            ToPicker.ItemsSource = AreaConverter.UnitNames;
            FromPicker.SelectedIndex = AreaConverter.IndexOf(AreaConverter.SquareMeter);
            ToPicker.SelectedIndex = AreaConverter.IndexOf(AreaConverter.SquareFoot);

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

            AreaUnit from = AreaConverter.Units[FromPicker.SelectedIndex];
            AreaUnit to = AreaConverter.Units[ToPicker.SelectedIndex];

            if (!double.TryParse(ValueEntry.Text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out double value))
            {
                ResultLabel.Text = "--";
                EquationLabel.Text = "Enter a number to convert";
                return;
            }

            double result = AreaConverter.Convert(value, from, to);

            ResultLabel.Text = Format(result);
            EquationLabel.Text = $"{Format(value)} {from.Name} = {Format(result)} {to.Name}";
        }

        private static string Format(double value)
            => value.ToString("G12", CultureInfo.CurrentCulture);
    }
}
