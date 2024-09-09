using PascalBoard.ExternClasses;
using Microsoft.Maui.Devices.Sensors;

namespace PascalBoard;

public partial class ShakeClass : ContentPage
{
    public static bool IsSupported { get; }
    private readonly DataStorage _storage;
    SensorSpeed speed = SensorSpeed.Game;
    private bool IsFlashlightOn = false;


    public ShakeClass(DataStorage dataStorage)
    {
        InitializeComponent();

        _storage = dataStorage;

        UpdateCountLabel();
    }

    private async void OnSwipedRight(object sender, SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync("///VibrationPage");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateCountLabel();

        // Start Accelerometer
        AddEventToAccelerometer();
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Stopped Accelerometer
        if (Accelerometer.Default.IsSupported)
        {
            RemoveEventToAccelerometer();
        }
    }
    private void UpdateCountLabel()
    {
        DisplayCountLabel.Text = $"EventCounter: { _storage.LoadData()}";
    }
    private async void Accelerometer_ShakeDetected(object sender, EventArgs e)
    {
        if (await Flashlight.IsSupportedAsync() && IsFlashlightOn == false)
        {
            await Flashlight.Default.TurnOnAsync();
            IsFlashlightOn = true;
            UpdateIndicatorLabel("On", Colors.Blue);

        }
        else
        {
            await Flashlight.Default.TurnOffAsync();
            IsFlashlightOn = false;
            UpdateIndicatorLabel("Off", Colors.Red);
        }

        _storage.SaveData(_storage.LoadData() + 1);
        UpdateCountLabel();
    }
    private async void AddEventToAccelerometer()
    {
        Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        Accelerometer.Default.Start(SensorSpeed.Game);

        
    }
    private  void RemoveEventToAccelerometer()
    {
        Accelerometer.Default.ShakeDetected -=  Accelerometer_ShakeDetected;
        Accelerometer.Default.Stop();
    }
    private async void UpdateIndicatorLabel(string status, Color color )
    {
        LightIndicator.Text = status;
        LightIndicator.TextColor = color;
    }





}