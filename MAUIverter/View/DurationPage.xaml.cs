using MAUIverter.ViewModel;

namespace MAUIverter.View
{
    public partial class DurationPage : ContentPage
    {
        private readonly DurationPageModel _model = new();

        public DurationPage()
        {
            InitializeComponent();
            BindingContext = _model;
            _model.ResultUpdated += OnResultUpdated;
        }

        private async void OnBackClicked(object? sender, EventArgs e)
            => await Navigation.PopAsync();

        private async void OnResultUpdated(object? sender, EventArgs e)
        {
            await ResultCard.FadeToAsync(0, 90);
            await ResultCard.ScaleToAsync(0.94, 90);
            await Task.WhenAll(ResultCard.FadeToAsync(1, 130), ResultCard.ScaleToAsync(1, 130));
        }
    }
}
