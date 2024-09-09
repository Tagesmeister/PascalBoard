using PascalBoard.ExternClasses;
using Microsoft.Maui.Devices.Sensors;


namespace PascalBoard;

public partial class BarPage : ContentPage
{
    private readonly DataStorage _storage;

    public BarPage(DataStorage dataStorage)
	{
        InitializeComponent();

        _storage = dataStorage;

        UpdateCountLabel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateCountLabel();
        ToggleBarometer();
    }
    private async void OnSwipedRight(object sender, SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync("///VibrationPage");
    }
    private void UpdateCountLabel()
    {
        DisplayCountLabel.Text = $"EventCounter: {_storage.LoadData()}";
    }

    public void ToggleBarometer()
    {
        if (Barometer.Default.IsSupported)
        {
            if (!Barometer.Default.IsMonitoring)
            {
                // Turn on barometer
                Barometer.Default.ReadingChanged += Barometer_ReadingChanged;
                Barometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off barometer
                Barometer.Default.Stop();
                Barometer.Default.ReadingChanged -= Barometer_ReadingChanged;


            }
        }
    }

    private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
    {
        // Update UI Label with barometer state
        DisplayBarData.TextColor = Colors.Green;
        DisplayBarData.Text = $"Barometer: {e.Reading}";
    }




}