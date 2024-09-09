namespace PascalBoard
{
    public partial class MainPage : ContentPage
    {
        private readonly DataStorage _storage;
       
        public MainPage(DataStorage dataStorage)
        {
            InitializeComponent();

            _storage = dataStorage;

            UpdateCountLabel();
        }

        private async void OnSwipedLeft(object sender, SwipedEventArgs e)
        {
            await Shell.Current.GoToAsync("///VibrationPage");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateCountLabel();
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

}
