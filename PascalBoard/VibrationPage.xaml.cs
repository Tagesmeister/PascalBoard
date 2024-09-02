namespace PascalBoard;

public partial class VibrationPage : ContentPage
{
	public VibrationPage()
	{
		InitializeComponent();
	}

    private async void OnSwipedLeft(object sender, SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync("///BarPage");
    }
    private async void OnSwipedRight(object sender, SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}