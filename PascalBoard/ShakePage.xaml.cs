using PascalBoard.ExternClasses;
using Microsoft.Maui.Devices.Sensors;

namespace PascalBoard;

public partial class ShakePage : ContentPage
{
   
    private readonly ActionClassShakePage _actionClassShakePage;
    public ShakePage(DataStorage dataStorage, ActionClassShakePage actionClassShakeClass)
    {
        InitializeComponent();

        _actionClassShakePage = actionClassShakeClass;

        // Register Events
        _actionClassShakePage.UpdateCountLabelAction = UpdateCountLabel;
        _actionClassShakePage.UpdateIndicatorLabelAction = UpdateIndicatorLabel;

        UpdateCountLabel();
    }


    private async void GoToVibrationPage(object sender, EventArgs e)
    {
        _actionClassShakePage.Navigate("VibrationPage");

    }
    private async void GoToSoundPage(object sender, EventArgs e)
    {
        _actionClassShakePage.Navigate("MainPage");

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateCountLabel();

        // Start Accelerometer
        _actionClassShakePage.AddEventToAccelerometer();
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Stopped Accelerometer
        if (Accelerometer.Default.IsSupported)
        {
            _actionClassShakePage.RemoveEventToAccelerometer();
        }
    }
    private void UpdateCountLabel()
    {
        DisplayCountLabel.Text = $"EventCounter: {_actionClassShakePage.LoadData()}";
    }

    private async void UpdateIndicatorLabel(string status, Color color )
    {
        LightIndicator.Text = status;
        LightIndicator.TextColor = color;
    }


}