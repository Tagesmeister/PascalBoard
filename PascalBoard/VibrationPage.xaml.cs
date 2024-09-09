namespace PascalBoard;

public partial class VibrationPage : ContentPage
{
    private readonly DataStorage _storage;

    public VibrationPage(DataStorage dataStorage)
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

    private async void OnSwipedLeft(object sender, SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync("///BarPage");
    }
    private async void OnSwipedRight(object sender, SwipedEventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
    private void ExecuteActionButton_Clicked(object sender, EventArgs e)
    {
        _storage.SaveData(_storage.LoadData() + 1);
        UpdateCountLabel();
    }
    private void UpdateCountLabel()
    {

        DisplayCountLabel.Text = $"EventCounter: {_storage.LoadData()}";
    }

}