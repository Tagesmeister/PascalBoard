using PascalBoard.ExternClasses;
using Microsoft.Maui.Devices.Sensors;

namespace PascalBoard;

public partial class ShakePage : ContentPage
{
   
    private readonly ActionClassShakePage _actionClassShakePage;
    public ShakePage(DataStorage dataStorage, ActionClassShakePage actionClassShakePage)
    {
        InitializeComponent();

        _actionClassShakePage = actionClassShakePage;

        // Register Events
        _actionClassShakePage.UpdateCountLabelAction = UpdateCountLabel;
        _actionClassShakePage.UpdateIndicatorLabelAction = UpdateIndicatorLabel;

        UpdateCountLabel();
    }


    private void GoToVibrationPage(object sender, EventArgs e)
    {
        _actionClassShakePage.Navigate("VibrationPage");

    }
    private void GoToSoundPage(object sender, EventArgs e)
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
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (width > height)
        {
            // Querformat




        }
        else
        {
            // Hochformat


        }
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

    private void UpdateIndicatorLabel(string status, Color color )
    {
        LightIndicator.Text = status;
        LightIndicator.TextColor = color;
    }


}