using PascalBoard.ExternClasses;
using Plugin.Maui.Audio;

namespace PascalBoard
{
    public partial class MainPage : ContentPage
    {
        private readonly ActionClassMainPage _actionClassMainPage;

        public MainPage(DataStorage dataStorage, ActionClassMainPage actionClassMainPage)
        {
            InitializeComponent();

            _actionClassMainPage = actionClassMainPage;
            UpdateCountLabel();
        }

        private async void GoToVibrationPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///VibrationPage");

        }
        private async void GoToLightPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///ShakePage");

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateCountLabel();
        }

        private void ExecuteActionButton_Clicked(object sender, EventArgs e)
        {
            _actionClassMainPage.SaveData(_actionClassMainPage.LoadData() + 1);
            UpdateCountLabel();

            _actionClassMainPage.PlaySound();
        }
        private void UpdateCountLabel()
        {
            DisplayCountLabel.Text = $"EventCounter: {_actionClassMainPage.LoadData()}";
        }


    }

}
