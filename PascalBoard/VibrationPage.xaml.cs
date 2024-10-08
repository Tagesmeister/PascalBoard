using PascalBoard.ExternClasses;

namespace PascalBoard;

public partial class VibrationPage : ContentPage
{
    private readonly ActionClassVibrationPage _actionClassVibrationPage;

    public VibrationPage(ActionClassVibrationPage actionClassVibrationPage)
	{
		InitializeComponent();

        _actionClassVibrationPage = actionClassVibrationPage;

        UpdateCountLabel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        UpdateCountLabel();
    }
    private void GoToSoundPage(object sender, EventArgs e)
    {
        _actionClassVibrationPage.Navigate("MainPage");


    }
    private void GoToLightPage(object sender, EventArgs e)
    {
        _actionClassVibrationPage.Navigate("ShakePage");


    }
    private void ExecuteActionButton_Clicked(object sender, EventArgs e)
    {
        _actionClassVibrationPage.SaveData(_actionClassVibrationPage.LoadData() + 1);
        UpdateCountLabel();

        _actionClassVibrationPage.StartVibration();
    }
    private void UpdateCountLabel()
    {

        DisplayCountLabel.Text = $"EventCounter: {_actionClassVibrationPage.LoadData()}";
    }
}