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
    }
    private async void OnSwipedRight(object sender, SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync("///VibrationPage");
    }
    private void UpdateCountLabel()
    {
        DisplayCountLabel.Text = $"EventCounter: {_storage.LoadData()}";
    }
}