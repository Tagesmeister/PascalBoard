using PascalBoard.ExternClasses;
using Plugin.Maui.Audio;

namespace PascalBoard
{
    public partial class MainPage : ContentPage
    {
        private readonly DataStorage _storage;
        private IAudioManager audioManager;

        public MainPage(DataStorage dataStorage, IAudioManager audioManager)
        {
            InitializeComponent();

            _storage = dataStorage;
            this.audioManager = audioManager;

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

            PlaySound();
        }
        private async void PlaySound()
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("VilligerSound.wav"));

            player.Play();
        }

        private void UpdateCountLabel()
        {
            DisplayCountLabel.Text = $"EventCounter: {_storage.LoadData()}";
        }
    }

}
