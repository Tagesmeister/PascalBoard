namespace PascalBoard;

public partial class BarPage : ContentPage
{
	public BarPage()
	{
        InitializeComponent();
	}

    private async void OnSwipedRight(object sender, SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync("///VibrationPage");
    }
}