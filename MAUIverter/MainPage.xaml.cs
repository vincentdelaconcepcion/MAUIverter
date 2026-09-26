namespace MAUIverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnInformationClicked(object? sender, EventArgs e)
            => await Navigation.PushAsync(new InformationPage());

        private async void OnVolumeClicked(object? sender, EventArgs e)
            => await Navigation.PushAsync(new VolumePage());

        private async void OnLengthClicked(object? sender, EventArgs e)
            => await Navigation.PushAsync(new LengthPage());

        private async void OnMassClicked(object? sender, EventArgs e)
            => await Navigation.PushAsync(new MassPage());

        private async void OnTemperatureClicked(object? sender, EventArgs e)
            => await Navigation.PushAsync(new TemperaturePage());

        private async void OnEnergyClicked(object? sender, EventArgs e)
            => await Navigation.PushAsync(new EnergyPage());

        private async void OnAreaClicked(object? sender, EventArgs e)
            => await Navigation.PushAsync(new AreaPage());

        private async void OnSpeedClicked(object? sender, EventArgs e)
            => await Navigation.PushAsync(new SpeedPage());

        private async void OnDurationClicked(object? sender, EventArgs e)
            => await Navigation.PushAsync(new DurationPage());
    }
}
